using System.Runtime.CompilerServices;
using Microsoft.Maui.HotReload;

namespace Readie.Controls;

public partial class NumericUpDown : ContentView, IHotReloadableView
{
    public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(int), typeof(NumericUpDown), 0);
    public static readonly BindableProperty MinValueProperty = BindableProperty.Create(nameof(MinValue), typeof(int), typeof(NumericUpDown), int.MinValue);
    public static readonly BindableProperty MaxValueProperty = BindableProperty.Create(nameof(MaxValue), typeof(int), typeof(NumericUpDown), int.MaxValue);
    public static readonly BindableProperty IncrementProperty = BindableProperty.Create(nameof(Increment), typeof(int), typeof(NumericUpDown), 1);
    public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(int), typeof(NumericUpDown), 14);
    public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(NumericUpDown), null);
    public static readonly BindableProperty BackColorProperty = BindableProperty.Create(nameof(BackColor), typeof(Color), typeof(NumericUpDown), Colors.Transparent);
    public static readonly BindableProperty AccentColorProperty = BindableProperty.Create(nameof(AccentColor), typeof(Color), typeof(NumericUpDown), Colors.Black);

    public int Value
    {
        get => (int)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public int MinValue
    {
        get => (int)GetValue(MinValueProperty);
        set => SetValue(MinValueProperty, value);
    }

    public int MaxValue
    {
        get => (int)GetValue(MaxValueProperty);
        set => SetValue(MaxValueProperty, value);
    }

    public int Increment
    {
        get => (int)GetValue(IncrementProperty);
        set => SetValue(IncrementProperty, value);
    }

    public int FontSize
    {
        get => (int)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    public string FontFamily
    {
        get => (string)GetValue(FontFamilyProperty);
        set => SetValue(FontFamilyProperty, value);
    }

    public Color BackColor
    {
        get => (Color)GetValue(BackColorProperty);
        set => SetValue(BackColorProperty, value);
    }

    public Color AccentColor
    {
        get => (Color)GetValue(AccentColorProperty);
        set => SetValue(AccentColorProperty, value);
    }

    public Command IncrementCommand { get; }
    public Command DecrementCommand { get; }

    public NumericUpDown()
    {
        InitializeComponent();
        DecrementCommand = new Command(() => Value = Math.Clamp(Value - Increment, MinValue, MaxValue));
        IncrementCommand = new Command(() => Value = Math.Clamp(Value + Increment, MinValue, MaxValue));
        BindingContext = this;
    }
}