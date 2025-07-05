# Ecommerce System

A comprehensive ecommerce system built in C# with .NET 9.0, featuring product management, shopping cart functionality, checkout processing, and shipping services.

## 🚀 Features

### Core Functionality
- **Product Management**: Add, retrieve, and manage products with stock tracking
- **Shopping Cart**: Add items, calculate totals, and manage quantities
- **Customer Management**: Handle customer accounts with balance tracking
- **Checkout System**: Complete purchase process with validation
- **Shipping Service**: Calculate shipping fees and generate shipment notices
- **Stock Management**: Real-time stock updates and validation

### Business Rules
- Products can be marked as shippable or non-shippable
- Products can have expiration dates
- Stock validation prevents overselling
- Customer balance validation during checkout
- Shipping fees calculated based on package weight

## 📁 Project Structure

```
EcommerceSytsem/
├── EcommerceSytsem/                 # Main application
│   ├── Product.cs                   # Product entity with stock management
│   ├── Customer.cs                  # Customer entity with balance management
│   ├── CartItem.cs                  # Shopping cart item
│   ├── ShoppingCart.cs              # Shopping cart with validation
│   ├── ShippedItem.cs               # Shippable item wrapper
│   ├── ShippingService.cs           # Shipping fee calculation and notices
│   ├── EcommerceSystem.cs           # Main system orchestrator
│   ├── CheckoutResult.cs            # Checkout result data
│   ├── IShipped.cs                  # Interface for shippable items
│   └── Program.cs                   # Application entry point
├── EcommerceSystemTests/            # Unit tests
│   ├── ProductTests.cs              # Product class tests
│   ├── CustomerTests.cs             # Customer class tests
│   ├── CartItemTests.cs             # Cart item tests
│   ├── ShippedItemTests.cs          # Shipped item tests
│   ├── ShippingServiceTests.cs      # Shipping service tests
└── EcommerceSytsem.sln              # Solution file
```

## 🛠️ Technology Stack

- **.NET 9.0**: Latest .NET framework
- **C#**: Primary programming language
- **xUnit**: Unit testing framework
- **Visual Studio 2022**: Recommended IDE

## 🏗️ Architecture

### Core Classes

#### Product
- Manages product information (name, price, stock, weight)
- Handles stock operations (increase/decrease)
- Validates expiration dates
- Tracks shippable status

#### Customer
- Manages customer information and balance
- Handles payment processing
- Validates sufficient balance for purchases

#### ShoppingCart
- Manages cart items and quantities
- Validates product availability and expiration
- Calculates subtotals
- Prevents adding invalid items

#### EcommerceSystem
- Orchestrates the entire checkout process
- Manages product catalog
- Handles business rule validation
- Generates receipts and shipment notices

#### ShippingService
- Calculates shipping fees based on weight
- Generates shipment notices
- Handles both shippable and non-shippable items

## 🧪 Testing

The project includes comprehensive unit tests covering:

- **Product Tests**: Stock management, expiration, validation
- **Customer Tests**: Balance management, payment validation
- **Cart Tests**: Item management, quantity validation, totals
- **Shipping Tests**: Fee calculation, notice generation
- **System Tests**: End-to-end checkout scenarios

### Running Tests

```bash
# Run all tests
dotnet test

# Run tests with verbose output
dotnet test --verbosity normal

# Run specific test class
dotnet test --filter "FullyQualifiedName~ProductTests"
```

## 📋 Business Rules

### Product Management
- Products must have valid names and prices
- Stock cannot go below zero
- Expired products cannot be purchased
- Products can be marked as non-shippable

### Shopping Cart
- Cannot add null products
- Cannot add negative quantities
- Cannot add out-of-stock products
- Cannot add expired products
- Cannot exceed available stock

### Checkout Process
- Cart cannot be empty
- All products must exist in system
- All products must be in stock
- All products must not be expired
- Customer must have sufficient balance
- Stock is automatically decreased after successful checkout

### Shipping
- Base shipping fee: 30 units
- Additional fee: 5 units per kg over 1kg
- Only shippable items incur shipping fees
- Shipment notices include item details and total weight

## 🚀 Getting Started

### Prerequisites
- .NET 9.0 SDK
- Visual Studio 2022 (recommended) or VS Code

### Installation

1. Clone the repository:
```bash
git clone <repository-url>
cd EcommerceSytsem
```

2. Build the solution:
```bash
dotnet build
```

3. Run the application:
```bash
dotnet run --project EcommerceSytsem
```

4. Run tests:
```bash
dotnet test
```

## 📝 Usage Examples

### Basic Product Management
```csharp
var system = new EcommerceSystem();
var product = new Product("Laptop", 999.99, 10, true);
system.AddProduct(product);
```

### Shopping Cart Operations
```csharp
var cart = new ShoppingCart();
var product = system.GetProduct("Laptop");
cart.AddItem(product, 2);
double subtotal = cart.SubTotal();
```

### Checkout Process
```csharp
var customer = new Customer("John Doe", 2000.0);
var result = system.Checkout(customer, cart);

if (result.Success)
{
    Console.WriteLine($"Checkout successful! Total: {result.PaidAmount}");
    Console.WriteLine(result.Receipt);
}
```

## 🔧 Configuration

The system uses default shipping rates:
- Base shipping fee: 30 units
- Weight fee: 5 units per kg over 1kg

These can be modified in the `ShippingService` class.

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add/update tests
5. Submit a pull request

## 📄 License

This project is licensed under the MIT License.

## 👥 Authors

- **Ahmed Talaat** - Initial work

## 🙏 Acknowledgments

- Built with .NET 9.0
- Tested with xUnit framework
- Follows SOLID principles and clean architecture patterns 
