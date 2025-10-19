using BlazorFizzBuzz.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorFizzBuzz.Components.Validators;

public class FizzBuzzValidator : ComponentBase, IDisposable
{
    private ValidationMessageStore validationMessageStore = null!;

    [CascadingParameter]
    private EditContext CurrentEditContext { get; set; } = default!;

    protected override void OnInitialized()
    {
        if (CurrentEditContext is null)
            throw new InvalidOperationException(
                $"{nameof(FizzBuzzValidator)} requires a cascading parameter of type " +
                $"{nameof(EditContext)}. For example, you can use {nameof(FizzBuzzValidator)} " +
                $"inside an {nameof(EditForm)}.");

        validationMessageStore = new(CurrentEditContext);

        // Suscribirse a eventos
        CurrentEditContext.OnFieldChanged += HandleFieldChanged;
        CurrentEditContext.OnValidationRequested += HandleValidationRequested;
    }

    private void HandleFieldChanged(object? sender, FieldChangedEventArgs e)
    {
        ValidateField(e.FieldIdentifier);
    }

    private void HandleValidationRequested(object? sender, ValidationRequestedEventArgs e)
    {
        ValidateAllFields();
    }

    private void ValidateField(FieldIdentifier fieldIdentifier)
    {
        var fizzbuzz = CurrentEditContext.Model as FizzBuzzModel
            ?? throw new InvalidOperationException($"{nameof(FizzBuzzValidator)} requires a model of type FizzBuzz.");

        // Limpia el campo que cambió
        validationMessageStore.Clear(fieldIdentifier);

        if (fieldIdentifier.FieldName == nameof(FizzBuzzModel.FizzValue))
        {
            validationMessageStore.Clear(CurrentEditContext.Field(nameof(FizzBuzzModel.BuzzValue)));

            if (fizzbuzz.FizzValue >= fizzbuzz.BuzzValue)
                validationMessageStore.Add(fieldIdentifier, "The Fizz value must be less than the Buzz value.");
        }

        if (fieldIdentifier.FieldName == nameof(FizzBuzzModel.BuzzValue))
        {
            validationMessageStore.Clear(CurrentEditContext.Field(nameof(FizzBuzzModel.FizzValue)));

            if (fizzbuzz.BuzzValue <= fizzbuzz.FizzValue)
                validationMessageStore.Add(fieldIdentifier, "The Buzz value must be greater than the Fizz value.");
        }

        if (fieldIdentifier.FieldName == nameof(FizzBuzzModel.StopValue))
        {
            int product = fizzbuzz.FizzValue * fizzbuzz.BuzzValue;
            if (fizzbuzz.StopValue < product)
                validationMessageStore.Add(fieldIdentifier, $"The Stop value must be greater or equal to {product}.");
        }

        // Notifica a Blazor que hay cambios
        CurrentEditContext.NotifyValidationStateChanged();
    }

    private void ValidateAllFields()
    {
        var fizzbuzz = CurrentEditContext.Model as FizzBuzzModel
            ?? throw new InvalidOperationException($"{nameof(FizzBuzzValidator)} requires a model of type FizzBuzz.");

        // Limpia todos los errores
        validationMessageStore.Clear();

        ValidateField(new FieldIdentifier(fizzbuzz, nameof(FizzBuzzModel.FizzValue)));
        ValidateField(new FieldIdentifier(fizzbuzz, nameof(FizzBuzzModel.BuzzValue)));
        ValidateField(new FieldIdentifier(fizzbuzz, nameof(FizzBuzzModel.StopValue)));

        CurrentEditContext.NotifyValidationStateChanged();
    }

    public void Dispose()
    {
        if (CurrentEditContext != null)
        {
            CurrentEditContext.OnFieldChanged -= HandleFieldChanged;
            CurrentEditContext.OnValidationRequested -= HandleValidationRequested;
        }

        GC.SuppressFinalize(this);
    }
}