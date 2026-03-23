# University Rental Service
A C# console app for managing university rental service of equipment like laptops, cameras, projectors and tablets. It handles user limits (Students vs. Employees), equipment availability and late return penalties.

Design Decisions
1. Responsibility + Cohesion
Models: Store data and handle their own logic (User knows its rental limits, Rental calculates penalties.
Service: Manages the checking if a rental is allowed before saving it.
Config: Business rules to make them easy to change.

2. Loose Coupling
Interfaces: I used IRentalService so the logic isn't tied to one specific implementation.
Inheritance: All gadgets inherit from Equipment. The system treats them the same, so adding a new type (like Tablet) doesn't require changing the core rental logic.

3. Data Persistence
Singleton Pattern: A Singleton database class provides a single, shared storage for Users and Equipment with no overhead like databases.
