# BakedProduct Management System

## Task-01 - Declaring and calling methods

## Overview

This project provides a structured and testable solution for modeling and working with baked products such as bread, pita, and buns. It is designed to simulate real-world bakery data handling, including ingredients, product composition, pricing, calorie calculations, sorting, filtering, and file persistence.

---

## Project Structure

### ClassLibrary

Contains core business logic, models, services, and utilities.

#### Products

* `BakedProduct`:

  * Represents a bakery product.
  * Implements `IBakedProduct` and `ICloneable`.
  * Supports price and calorie calculation, deep cloning, comparison.
* `ProductCategory`:

  * Enum representing categories such as Bread, Bun, Bagel, Pita.
* Optional derived types (e.g., `Bread`, `Pita`) exist for future extensibility.

#### Ingredients

* `Ingredient`:

  * Represents a product component.
  * Includes properties for name, calorie density, unit price, and weight.
  * Supports deep cloning and object comparison.

#### Services

* `ProductFinding`:

  * Search by price and calorie similarity.
  * Search by ingredient weight threshold.
  * Search by minimum ingredient count.

* `ProductSorting`:

  * Clone and sort by calories.
  * Shallow copy and sort by price.

* `Parser`:

  * JSON serialization/deserialization of product arrays.
  * Case-insensitive and enum-as-string handling.

* `FileService`:

  * Save and read file content.
  * Check file existence and delete files.

* `FolderService`:

  * Create directories.
  * Check existence and delete folders.

#### Utilities

* `Guard`:

  * Validates method arguments.
  * Throws exceptions for null, empty, zero, and negative values.

---

## ClassLibrary.Tests

Unit testing project using NUnit.

### Features:

* Full test coverage for:

  * `BakedProduct` and `Ingredient` classes
  * `ProductSorting`, `ProductFinding`, `Parser`
  * `FileService`, `FolderService`
  * `Guard`
* Reusable test data defined in `TestData` helper class
* Temporary file and folder management using `Path.GetTempPath()` and GUID-based naming

---

## Supported Functionalities

* Load and save product data in JSON format
* Calculate total calories and price based on ingredient composition and markup
* Sort products by calories or price
* Find products by criteria (ingredient weight, total attributes)
* Work with files and folders
* Validate input arguments across the entire codebase

---

## Sample Data Format (JSON)

```json
[
  {
    "name": "Georgian",
    "productCategory": "Pita",
    "markup": 1.2,
    "ingredients": [
      { "name": "Flour", "weight": 0.3, "calorie": 364, "price": 1 },
      { "name": "Water", "weight": 0.1, "calorie": 0, "price": 0.016 },
      { "name": "Salt", "weight": 0.01, "calorie": 0, "price": 0.65 }
    ]
  }
]
```

---

## Tools and Technologies

* C# .NET (Class Library + NUnit Testing)
* JSON Serialization via `System.Text.Json`
* NUnit for unit testing
* Visual Studio Code Coverage for test analysis

---

## Getting Started

To run the solution:

1. Open the solution in Visual Studio or your preferred IDE.
2. Build the solution.
3. Run tests via Test Explorer or command line (`dotnet test`).
4. Use coverage tools to inspect test coverage.

---

## Author

Developed by Andrei Samusenka as part of a test task for EPAM Systems.
