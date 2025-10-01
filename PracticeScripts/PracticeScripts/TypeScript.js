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
var anyValue = "hello";
anyValue.foo.bar(); // No error at compile time, but will crash at runtime.
var unknownValue = "hello";
// unknownValue.toUpperCase(); // Error: Object is of type 'unknown'.
if (typeof unknownValue === "string") {
    unknownValue.toUpperCase(); // OK, type is narrowed to 'string'
}
//#endregion
// #region Generic
/*Generics allow you to create reusable components that work over a variety of types rather than a single one.They act as placeholders for types.

    Usefulness: They provide flexibility while maintaining type safety.
*/
// Without Generic - only works for number
function identityNumber(arg) {
    return arg;
}
// With Generic - works for any type
function identity(arg) {
    return arg;
}
var output1 = identity("myString"); // T is string
var output2 = identity(42); // Type Inference: T is number
// #endregion
// #region Union Type (|) and an Intersection Type (&)?
/*
    Union (A | B): A value that can be one of several types.

    Intersection (A & B): A value that must satisfy all of the given types simultaneously.
*/
// Union
var id;
id = "ABC123"; // OK
id = 123; // OK
var person = { name: "Alice", age: 30 }; // Must have both properties
var p = { x: 10, y: 20 };
// p.x = 5; // Error! Cannot assign to 'x' because it is a read-only property.
// as const
var colors = ["red", "green"];
var user1 = { name: "Bob" }; // OK
var user2 = { name: "Alice", email: "alice@example.com" }; // Also OK
function getProperty(obj, key) {
    return obj[key];
}
// The resulting Box interface has both `height` and `width`.
var box = { height: 10, width: 20 };
// { x: number; y: number; }
//#endregion
//#Region TypeScript Course - Mastering TypeScript - 2025
// .ts => TypeScript file
// .tsx => TypeScript + JSX (React)
Math.round(12.5);
//to run a ts file use: tsc fileName.ts and file TypeScript.js will be created
//Variables and Types
var isBeginner = true;
var total = 0;
var names = "Luis";
names.toUpperCase();
//#endregion
