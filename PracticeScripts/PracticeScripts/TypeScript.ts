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

// #region Generic
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
