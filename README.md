# 🎯 FizzBuzz Blazor WebAssembly

A modern, interactive FizzBuzz implementation built with Blazor WebAssembly, featuring custom validation, responsive design, and .NET best practices.

## ✨ Features

* 🌐 **Blazor WebAssembly** - Runs entirely in the browser with C# and .NET
* ✅ **Custom Validation Component** - Real-time client-side validation without Data Annotations
* 📱 **Responsive Design** - Mobile-first UI using Bootstrap 5
* ⚡ **Real-time Feedback** - Instant validation as users type
* 🎨 **Modern UI/UX** - Clean, intuitive interface with Bootstrap components
* 🏗️ **Best Practices** - Clean architecture, separation of concerns, SOLID principles
* 🔒 **Business Rules** - Enforces logical constraints (Fizz < Buzz, Stop >= Fizz × Buzz)

## 📋 Prerequisites

Before you begin, ensure you have installed:

* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
* A modern web browser (Chrome, Firefox, Edge, Safari)
* (Optional) Visual Studio 2022, VS Code, or JetBrains Rider

## 🚀 Getting Started

### Installation

Clone the repository:

```bash
git clone https://github.com/abeltran12/FizzBuzzBlazor.git
cd FizzBuzzBlazor
```

Restore dependencies:

```bash
dotnet restore
```

Run the application:

```bash
dotnet run
```

Or with hot reload:

```bash
dotnet watch run
```

Open your browser and navigate to `https://localhost:5269` (port may vary - check terminal output)

## 📁 Project Structure

```
BlazorFizzBuzz/
├── Components/
│   ├── Layout/                 # Layout components
│   │   ├── TopNavLayout.razor
│   │   ├── TopNavMenu.razor
│   │   └── TopNavFooter.razor
│   ├── Pages/                  # Routable pages
│   │   ├── Home.razor
│   │   ├── FizzBuzz.razor      # Main FizzBuzz page
│   ├── UI/                     # Reusable UI components
│   │   └── FizzBuzzItem.razor
│   └── Validators/             # Custom validation components
│       └── FizzBuzzValidator.cs
├── Models/
│   └── FizzBuzzModel.cs        # FizzBuzz data model
├── wwwroot/                    # Static files
│   ├── css/
│   ├── images/
│   └── favicon.png
├── _Imports.razor              # Global using directives
├── App.razor                   # Root component
├── Program.cs                  # Application entry point
└── BlazorFizzBuzz.csproj       # Project file
```

## 🎯 How It Works

### FizzBuzz Algorithm

The classic FizzBuzz problem with customizable parameters:

* **FizzValue**: Multiples of this number display "Fizz"
* **BuzzValue**: Multiples of this number display "Buzz"
* **StopValue**: Upper limit for number generation

**Rules:**

* If number is divisible by both → "FizzBuzz"
* If divisible by FizzValue only → "Fizz"
* If divisible by BuzzValue only → "Buzz"
* Otherwise → the number itself

### Custom Validation

The project implements a custom validator component (`FizzBuzzValidator.cs`) that:

* Validates without Data Annotations
* Provides real-time field-level validation
* Enforces business rules:
  * `FizzValue < BuzzValue`
  * `StopValue >= FizzValue × BuzzValue`
* Clears related field errors intelligently
* Implements `IDisposable` for proper cleanup

Example validation logic:

```csharp
if (fizzbuzz.FizzValue >= fizzbuzz.BuzzValue)
{
    validationMessageStore.Add(fieldIdentifier, 
        "The Fizz value must be less than the Buzz value.");
}
```

## 🎨 UI/UX Design

### Responsive Design

* Mobile-first approach using Bootstrap 5 grid system
* Responsive columns: `col-md-4` for medium+ screens
* Stacks vertically on small screens

### Bootstrap Components Used

* Forms (`form-control`, `form-label`)
* Buttons (`btn`, `btn-primary`)
* Grid System (`container`, `row`, `col`)
* Validation Messages (`form-text`, `text-danger`)
* Borders & Utilities (`border`, `rounded`, `p-4`)

## 🏗️ Best Practices Implemented

### Architecture

* **Separation of Concerns** - Models, Components, Validators separated
* **Single Responsibility Principle** - Each component has one job
* **DRY (Don't Repeat Yourself)** - Reusable components
* **Component-Based Design** - Modular, testable structure

### Code Quality

* **Null Safety** - Using nullable reference types
* **Resource Management** - Proper `IDisposable` implementation
* **Event Unsubscription** - Prevents memory leaks
* **Naming Conventions** - Clear, descriptive names

### Performance

* **Field-Level Validation** - Only validates changed fields
* **Efficient Re-renders** - Blazor's diffing algorithm
* **WebAssembly** - Client-side execution, no server round-trips

## 💡 Usage Example

1. Enter **FizzValue** (e.g., 3)
2. Enter **BuzzValue** (e.g., 5) - Must be greater than FizzValue
3. Enter **StopValue** (e.g., 20) - Must be >= FizzValue × BuzzValue
4. Click **"Generate"**
5. View results - Numbers, Fizz, Buzz, or FizzBuzz displayed

Example Output:

```
1, 2, Fizz, 4, Buzz, Fizz, 7, 8, Fizz, Buzz, 11, Fizz, 13, 14, FizzBuzz, 16, ...
```

## 🛠️ Technologies Used

* **.NET 9** - Runtime and framework
* **Blazor WebAssembly** - UI framework
* **C# 12** - Programming language
* **Bootstrap 5.3** - CSS framework
* **HTML5** - Markup
* **CSS3** - Styling

## 📚 Learning Resources

This project demonstrates:

* Custom validation in Blazor without FluentValidation
* EditContext and ValidationMessageStore usage
* Component lifecycle (`OnInitialized`, `Dispose`)
* Event subscription/unsubscription pattern
* Bootstrap integration in Blazor
* Responsive design principles

## 📝 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 👤 Author

**Andres Beltran**

## 🙏 Acknowledgments

* Inspired by the classic FizzBuzz programming challenge
* Built with love using Blazor WebAssembly
* Bootstrap for the beautiful, responsive UI
* Microsoft documentation for best practices

---

<div align="center">
Made with ❤️ using Blazor WebAssembly
</div>
