using System.Windows;
using System.Windows.Threading;
using TriggerValoran.Interfase.IColorServices;
using TriggerValoran.Interfase.IEvenClickServices;
using TriggerValoran.Interfase.IJsonServices;
using TriggerValoran.Interfase.IMemoryButtonServices;
using TriggerValoran.Interfase.IScreenServices;
using TriggerValoran.Interfase.ITriggerServices;
using TriggerValoran.Model.MemoryButton;
using TriggerValoran.Model.TriggerSettings;
using TriggerValoran.Service.ButtonServices;
using TriggerValoran.Service.ColorServices;
using TriggerValoran.Service.EvenServices;
using TriggerValoran.Service.JsonServices;
using TriggerValoran.Service.ScreenServices;
using TriggerValoran.Service.TriggerServices;
using TriggerValoran.Service.WorkWithServices;
using Brushes = System.Windows.Media.Brushes;

namespace TriggerValoran;

public partial class MainWindow : Window
{
    private IButtonServices _buttonServices;
    private ITriggerServices _triggerServices;
    private IColorServices _colorServices;
    private IEvenServices _evenServices;
    private IScreenServices _screenServices;
    private readonly DispatcherTimer _dispatcherTimer;
    private IJsonServices<TriggerSettings> _TjsonServices;
    private IJsonServices<MemoryButton> _BjsonServices;

    private int _boxY;
    private int _boxX;
    private int _sleepRepeatTime;
    private int _sleepOneTime;
    private string _boxColor = "Purple";
    private int _countFire = 2;
    private bool _isSitDown;
    private bool _isWalkStop;

    public MainWindow()
    {
        InitializeComponent();

        _dispatcherTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(0)
        };
        _dispatcherTimer.Start();
        _dispatcherTimer.Tick += TimerTick;
    }

    private void TimerTick(object? sender, EventArgs e)
    {
        if (_triggerServices == null)
        {
            _buttonServices = new ButtonServices();
            _colorServices = new ColorServices();
            _evenServices = new EvenServices(_buttonServices);
            _screenServices = new ScreenServices();
            _TjsonServices = new JsonServices<TriggerSettings>();
            _BjsonServices = new JsonServices<MemoryButton>();
            _triggerServices =
                new TriggerServices(new WorkWithServices(_colorServices, _evenServices, _screenServices,
                    _TjsonServices, _BjsonServices, _buttonServices));
        }

        _triggerServices.Trigger(
            new TriggerSettings(_countFire, _boxX, _boxY, _sleepRepeatTime, _sleepOneTime,_boxColor, _isSitDown, _isWalkStop, 1, 1, 1, 1),
            _dispatcherTimer);
    }

    private void BoxX(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        TextX.Text = $"Box по X {e.NewValue.ToString("0")}px";
        _boxX = (int)e.NewValue;
    }

    private void BoxY(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        TextY.Text = $"Box по Y {e.NewValue.ToString("0")}px";
        _boxY = (int)e.NewValue;
    }

    private void SleepRepeatFire(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        TextSleep.Text = $"Повторный выстрел время {e.NewValue.ToString("0")} секунд";
        _sleepRepeatTime = (int)e.NewValue;
    }

    private void SleepOneFire(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        TextSleepFire.Text = $"Повторный выстрел время {e.NewValue.ToString("0")} секунд";
        _sleepOneTime = (int)e.NewValue;
    }
    
    private void SitDown(object sender, RoutedEventArgs e)
    {
        _isSitDown = !_isSitDown;
    }

    private void WalkStop(object sender, RoutedEventArgs e)
    {
        _isWalkStop = !_isWalkStop;
    }

    private void OffSitDown(object sender, RoutedEventArgs e)
    {
        _isSitDown = !_isSitDown;
    }

    private void OffWalkStop(object sender, RoutedEventArgs e)
    {
        _isWalkStop = !_isWalkStop;
    }

    private void OpenColor(object sender, RoutedEventArgs e)
    {
        Color.IsOpen = true;
    }

    private void OpenCountFire(object sender, RoutedEventArgs e)
    {
        CountFire.IsOpen = true;
    }

    private void Count3(object sender, RoutedEventArgs e)
    {
        NameItemCountFire.Content = "3" + "выстрел";
        CountFire.IsOpen = false;
    }

    private void Count1(object sender, RoutedEventArgs e)
    {
        NameItemCountFire.Content = "1" + "выстрел";
        _countFire = 1;
        CountFire.IsOpen = false;
    }

    private void Count2(object sender, RoutedEventArgs e)
    {
        NameItemCountFire.Content = "2" + "выстрел";
        _countFire = 2;
        CountFire.IsOpen = false;
    }

    private void ColorPurple(object sender, RoutedEventArgs e)
    {
        NameItemColor.Content = "Фиолетовый";
        NameItemColor.Background = Brushes.Purple;
        _boxColor = "Purple";
        Color.IsOpen = false;
    }

    private void ColorRed(object sender, RoutedEventArgs e)
    {
        NameItemColor.Content = "Красный";
        NameItemColor.Background = Brushes.Red;
        _boxColor = "Red";
        Color.IsOpen = false;
    }

    private void ColorYellow(object sender, RoutedEventArgs e)
    {
        NameItemColor.Content = "Желтый";
        NameItemColor.Background = Brushes.Yellow;
        _boxColor = "Yellow";
        Color.IsOpen = false;
    }

    private void Save(object sender, RoutedEventArgs e)
    {
        _triggerServices.Save(new TriggerSettings(_countFire, _boxX, _boxY, _sleepRepeatTime, _sleepOneTime, _boxColor,
            _isSitDown, _isWalkStop, 1, 1, 1, 1));
    }

    private void Get(object sender, RoutedEventArgs e)
    {
        TriggerSettings? jTriggerSettings = _triggerServices.GetSave();
        if (jTriggerSettings != null)
        {
            _countFire = jTriggerSettings.Count;
            _boxX = jTriggerSettings.BoxSizeX;
            _boxY = jTriggerSettings.BoxSizeY;
            _sleepRepeatTime = jTriggerSettings.SleepTimeRepeatFire;
            _sleepOneTime = jTriggerSettings.SleepTimeOneFire;
            _boxColor = jTriggerSettings.BoxColor;
            _isSitDown = jTriggerSettings.SitDown;
            _isWalkStop = jTriggerSettings.WalkStop;
        }

        SliderY.Value = _boxY;
        SliderX.Value = _boxX;
        SliderTime.Value = _sleepRepeatTime;
        NameItemCountFire.Content = _countFire + "выстрел";
        IsSitDown.IsChecked = _isSitDown;
        IsWalkStop.IsChecked = _isWalkStop;
        SliderTimeFire.Value = _sleepOneTime;

        switch (_boxColor)
        {
            case "Purple":
                NameItemColor.Content = "Фиолетовый";
                NameItemColor.Background = Brushes.Purple;
                break;
            case "Yellow":
                NameItemColor.Content = "Желтый";
                NameItemColor.Background = Brushes.Yellow;
                break;
            case "Red":
                NameItemColor.Content = "Красный";
                NameItemColor.Background = Brushes.Red;
                break;
        }
    }
}