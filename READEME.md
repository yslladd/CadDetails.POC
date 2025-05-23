### Challenge 1: Revenue Calculation Refactor
The whole solution is built following best practices of the Clean Code architecture and SOLID Principles

## Refactoring Overview: Revenue Calculation

This project includes a refactored implementation of a revenue calculation service using **SOLID principles** and **Clean Code practices** to improve clarity, 
maintainability, and testability.

### Original Problem

The initial method, `CalculateTotalRevenue`, was a procedural loop with logic tightly coupled to data structures. It lacked validation, made testing difficult, and violated key software design principles.

### Refactored Approach

We introduced an `IOrderService` interface with a concrete `OrderService` implementation, enabling **dependency injection** and adhering to the **Dependency Inversion Principle**. Core business logic was moved into the domain models (`Order` and `Product`) through methods like `ShouldProcess()` and `IsValid()`, keeping logic encapsulated and expressive.

The refactored service:
- Filters out orders that are canceled or older than one year.
- Validates product data (ensuring price ≥ 0 and quantity ≥ 0).
- Applies discounts per order, not globally.
- Computes revenue in a modular, testable way.

### Testing

We used **xUnit** to create a complete unit test suite covering all edge cases, including:
- Null or invalid products
- Discount application
- Empty orders
- Skipped orders due to validation

This structure ensures clear separation of concerns and promotes long-term code quality.

### Challenge 2: Asset Sorting Refactor

The original implementation used a naive in-place bubble sort algorithm inside a ListProcessor class to sort a list of integers. While it demonstrated the basic sorting logic, it was inefficient (O(n²) complexity), hard to maintain, and tightly coupled to the data type and sorting rules. It also violated several SOLID principles, especially the Single Responsibility Principle and the Open/Closed Principle.

In the refactored solution, we introduced a proper domain model (Asset) and used the Strategy Pattern to externalize sorting behavior. The sorting logic now adheres to Clean Code and Domain-Driven Design principles by moving behavior to appropriate places and decoupling algorithm selection from the sorting execution.

Sorting supports multiple criteria:

- LastUpdated (descending)
- PopularityScore (descending)
- Name (ascending)
- All while gracefully handling null values.
