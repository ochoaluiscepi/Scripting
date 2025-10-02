// #region What is TypeScript and why use it over JavaScript?
/*
    
    TypeScript is a statically typed superset of JavaScript that compiles to plain JavaScript. Its key advantages are:

    Static Typing: Catches type-related errors at compile-time, not runtime.
    Enhanced IDE Support: Better autocompletion, navigation, and refactoring.
    Improved Readability & Maintainability: Types act as documentation for your code.
    Early Error Detection: Finds bugs before the code even runs.
*/
//#endregion

// #region built-in types in TypeScript
/*
    string, number, boolean, null, undefined, void, object, symbol, bigint. Also, arrays: number[] or Array<number>.
*/
//#endregion

// #region How do you define a function in TypeScript with typed parameters and a return type?
/*
    any: Opts out of type checking. A variable of type any can be assigned to any value and you can call any property/method on it. 
    Use sparingly, as it defeats the purpose of TypeScript.

    unknown: A type-safe counterpart of any. You can assign any value to an unknown variable, 
    but you cannot access its properties or call it without first narrowing its type (e.g., using type guards).

    Prefer unknown over any when you don't know the type of a value (e.g., from a 3rd party API) but still want to maintain type safety.
*/
let anyValue: any = "hello";
anyValue.foo.bar(); // No error at compile time, but will crash at runtime.

let unknownValue: unknown = "hello";
// unknownValue.toUpperCase(); // Error: Object is of type 'unknown'.
if (typeof unknownValue === "string") {
    unknownValue.toUpperCase(); // OK, type is narrowed to 'string'
}

//#endregion

// #region interface and type?
/*
    They are very similar and often interchangeable, but have some key differences:

    interface:

        Primarily for defining the shape of an object.
        Can be extended using extends.
        Can be re-opened (declaration merging).

    type (Type Alias):
        Can define a wider range of types: primitives, unions, tuples, etc.
        Can use intersection (&).
        Cannot be re-opened.
*/
// Interface
interface Persons {
    name: string;
}
interface Employee extends Person {
    employeeId: number;
}

// Type Alias
type Name = string;
type PersonOrEmployee = Person | Employee;
type PersonTuple = [string, number]; // Tuple

// Interface Declaration Merging
interface Persons { age: number; } // Merges with the first Person declaration

//#endregion

// #region Generics
/*Generics allow you to create reusable components that work over a variety of types rather than a single one.They act as placeholders for types.

    Usefulness: They provide flexibility while maintaining type safety.
*/

// Without Generic - only works for number
function identityNumber(arg: number): number {
    return arg;
}

// With Generic - works for any type
function identity<T>(arg: T): T {
    return arg;
}
const output1 = identity<string>("myString"); // T is string
const output2 = identity(42); // Type Inference: T is number
// #endregion

// #region Union Type (|) and an Intersection Type (&)?
/*
    Union (A | B): A value that can be one of several types.

    Intersection (A & B): A value that must satisfy all of the given types simultaneously.
*/
// Union
let id: string | number;
id = "ABC123"; // OK
id = 123; // OK

// Intersection
interface Named { name: string; }
interface Aged { age: number; }
type Person = Named & Aged;
const person: Person = { name: "Alice", age: 30 }; // Must have both properties

//#endregion

//#region readonly and const assertions (as const).
/*
    readonly: A modifier for properties/arrays that makes them immutable after initialization.

    as const: A const assertion that tells TypeScript to infer the most specific, literal type possible, making all properties readonly.
*/

// readonly
interface Point {
    readonly x: number;
    readonly y: number;
}
let p: Point = { x: 10, y: 20 };
// p.x = 5; // Error! Cannot assign to 'x' because it is a read-only property.

// as const
const colors = ["red", "green"] as const;
// colors.push("blue"); // Error! Property 'push' does not exist on type 'readonly ["red", "green"]'.

//#endregion

//#region optional properties in an interface?

// Using the ? operator. 
interface User {
    name: string;
    email?: string; // This property is optional
}
const user1: User = { name: "Bob" }; // OK
const user2: User = { name: "Alice", email: "alice@example.com" }; // Also OK

//#endregion

//#region Guards
/*
    Type Guards are expressions that perform a runtime check to narrow down the type within a scope.

    typeof guard: For primitives (string, number, boolean, symbol).
    instanceof guard: For classes.
    in guard: To check for the existence of a property.
    User-Defined Type Guard: A function with a return type predicate (arg is Type).


User-Defined Type Guard

function isFish(pet: Fish | Bird): pet is Fish {
    return (pet as Fish).swim !== undefined;
}

let pet: Fish | Bird = getSmallPet();
if (isFish(pet)) {
    pet.swim(); // TypeScript knows 'pet' is Fish here
} else {
    pet.fly(); // TypeScript knows 'pet' is Bird here
}
*/
//#endregion

//#region keyof

//The keyof operator takes an object type and produces a union of its keys.
interface Persons {
    name: string;
    age: number;
}
type PersonKeys = keyof Persons; // "name" | "age"

function getProperty<T, K extends keyof T>(obj: T, key: K): T[K] {
    return obj[key];
}

//#endregion

//#region Conditional Types
//A type that is selected based on a condition, expressed as T extends U ? X : Y.
type IsString<T> = T extends string ? true : false;
type A = IsString<string>; // true
type B = IsString<number>; // false

// Used heavily in utility types
type NonNullables<T> = T extends null | undefined ? never : T;
//#endregion

//#region Mapped Types
//A generic type which uses a union of keyof to iterate through keys to create a new type.

// Make all properties optional
type Optional<T> = {
    [P in keyof T]?: T[P];
};

// Make all properties readonly
type Readonlys<T> = {
    readonly [P in keyof T]: T[P];
};

interface Persons {
    name: string;
    age: number;
}
type ReadonlyPerson = Readonly<Person>;
// { readonly name: string; readonly age: number; }
//#endregion

//#region Template Literal Types
//They allow you to use string literal types to create new string literal types, similar to template strings in JavaScript.
type EventName = "click" | "hover";
type HandlerName = `on${Capitalize<EventName>}`; // "onClick" | "onHover"

//#endregion

//#region Declaration Merging
//A feature where the TypeScript compiler merges two separate declarations with the same name into a single definition. This is most common with interfaces.
interface Box {
    height: number;
}
interface Box {
    width: number;
}
// The resulting Box interface has both `height` and `width`.
const box: Box = { height: 10, width: 20 };


//#endregion

//#region tsconfig.json
/*
It's the configuration file for a TypeScript project.

Important Options:
    target: The ECMAScript target version (e.g., es5, es6, es2020).
    module: The module system (e.g., commonjs, esnext).
    strict: Enables all strict type-checking options (highly recommended).
    outDir: The output directory for compiled files.
    rootDir: The root directory of your source files.
    esModuleInterop: Allows default imports from CommonJS modules.
*/
//#endregion

//#region Declare
//It's used to tell TypeScript that a variable, function,
//or class exists elsewhere(e.g., in a script loaded via a < script > tag) and not to worry about its implementation.It's purely for type information.

// Declare a global variable from a script tag
declare const MY_GLOBAL: string;
// Declare a module for a non-typed JS library
declare module "my-untyped-library";


//#endregion

//#region Problem-Solving / Coding
/*
How would you type a function that takes an object and a key, and returns the value of that key?

Answer: Use Generics with constraints (K extends keyof T).


function getProperty<T, K extends keyof T>(obj: T, key: K): T[K] {
    return obj[key];
}

const person = { name: "Alice", age: 30 };
const name = getProperty(person, "name"); // type: string
const age = getProperty(person, "age"); // type: number

// const invalid = getProperty(person, "foo"); // Error! Argument of type '"foo"' is not assignable to parameter of type '"name" | "age"'.
*/
//___________________________________________________________________________________________________________________________________________________
//___________________________________________________________________________________________________________________________________________________
//___________________________________________________________________________________________________________________________________________________
/*
How would you create a type that makes all properties of an interface mutable (removes readonly)?
Answer: Use a Mapped Type.

*/
type Mutable<T> = {
    -readonly [P in keyof T]: T[P]; // The '-' modifier removes readonly
};

interface ReadonlyPoint {
    readonly x: number;
    readonly y: number;
}
type MutablePoint = Mutable<ReadonlyPoint>;
// { x: number; y: number; }

//#endregion

//__________________________________________________________________________________________________________________________
//__________________________________________________________________________________________________________________________
//__________________________________________________________________________________________________________________________
//#region TypeScript Course - Mastering TypeScript - 2025

// .ts => TypeScript file
// .tsx => TypeScript + JSX (React)

Math.round(12.5);

//to run a ts file use: tsc fileName.ts and file TypeScript.js will be created

//#endregion

// #region Variables and Types
const isBeginner: boolean = true;
const total: number = 0;
const names: string = "Luis";

names.toUpperCase();

//Type Inference: TypeScript automatically infers types when there is an initial value
let sentence = `My name is ${names} I am a beginner in TypeScript`;

//Any: turns off type checking fot the variable 
let n: any = 10;
n = true;
n = "string";

let movies = ["Inception", "Interstellar", "The Dark Knight"];

//compiler creates an array of type any[]

let foundMovie;

//to avoid this we can define the type of the array
let movies2: string[] = ["Inception", "Interstellar", "The Dark Knight"];
// movies2.push(5); //Error
let movies3: Array<string> = ["Inception", "Interstellar", "The Dark Knight"];

//#endregion

//#region Function Parameter Annotations
//We can specify the type of each parameter and the return type of the function
function square(num: number): number {
    return num * num;
}

//function with optional parameter (and return value => : number {})
function squareOptional(num1: number, num2?: number): number {
    return num2 ? num1 * num2 : num1 * num1;
}

const squareDifferentFunctionDefinition = function (num: number): number {
    return num * num;
}
squareDifferentFunctionDefinition(5);


//Default Parameters
function squareWithDefault(num: number = 10): number {
    return num * num;
}

//Arrow Function
 const squareArrow = (num: number): number => num * num;

//#endregion

//#region Anonymous Function

const numbersTest = [1, 2, 3, 4, 5];
numbersTest.forEach((num) => console.log(num));

const colorTest = ["Red", "Green", "Blue"];
colorTest.map((color: string) => color.toUpperCase());
//
//#endregion

//#region Void Type
//void type is used when a function does not return a value
function logMessage(message: string): void {
    console.log(message);
}
//#endregion

//#region Never Type
//never type is used when a function never returns (e.g., throws an error or infinite loop)

function makeError(message: string): never {
    throw new Error(message);
}

function gameLoop(): never {
    while (true) {
        console.log("Game Loop");
    }
}
//#endregion

//#region Exercise
// **********************************************
// ******************* PART 1 *******************
// **********************************************
// Write a function called "twoFer" that accepts a person's name
// It should return a string in the format "one for <name>, one for me"
// If no name is provided, it should default to "you"

// twoFer() => "One for you, one for me"
// twoFer("Elton") => "One for Elton, one for me"

function twoFer(name: string = "you"): string {
    return `One for ${name}, one for me`;
}

// **********************************************
// ******************* PART 2 *******************
// **********************************************
// Write a isLeapyear() function that accepts a year and returns true/false depending on if the year is a leap year
// isLeapYear(2012) => true
// isLeapYear(2013) => false

// To determine whether a year is a leapyear, use this "formula":
// A YEAR IS A LEAPYEAR IF
// - year is a multiple of 4 AND not a multiple of 100
// OR...
// - year is a multiple of 400
// hint - use modulo

function isLeapYear(year: number): boolean {
    return (year % 4 === 0 && year % 100 !== 0) || (year % 400 === 0);
}

console.log(isLeapYear(2012)); // true
//#endregion

//#region Object Types
const dog = {
    name: "Buddy",
    breed: "Golden Retriever",
    age: 3
}

function printDog(dog: { name: string; breed: string; age: number }): void {
    console.log(`Dog's name is ${dog.name}, breed is ${dog.breed} and age is ${dog.age}`);
}

printDog(dog);

//assign object type to a variable(not common use)
const myCar: { make: string; model: string; year: number } = { make: "Toyota", model: "Camry", year: 2020 };

//return object from a function
function randomCar(): { make: string; model: string; year: number } {
    return { make: "Honda", model: "Civic", year: 2019 };
}

//#endregion

//#region Alias
//It is use to create a new name for a type
type Car = {
    make: string; 
    model: string;
    year: number;
};
function printCar(car: Car): Car {

    return { make:"Mazda", model:"cx3", year:2025 };
}
//#endregion

//#region NestedObjects

type PersonAddress = {
    name: string,
    address: {
        street: string,
        city: string,
        country: string,
    },
 };

function describePerson(person: PersonAddress): string {
    return `Person: ${person.name}, street ${person.address.street} `;
}

const Me = {
    name: "Luis",
    address: {
        street: "Guadalajara",
        city: "Zapopan",
        country: "Mexico",
    },
};

console.log(describePerson(Me));
//#endregion
