using System.Net.Http;
using System.Windows;
using System.Windows.Threading;
using TriggerValoran.Interface.IColorServices;
using TriggerValoran.Interface.IEvenClickServices;
using TriggerValoran.Interface.IHttpServices;
using TriggerValoran.Interface.IHttpServicesRequest;
using TriggerValoran.Interface.IJsonServices;
using TriggerValoran.Interface.IMemoryButtonServices;
using TriggerValoran.Interface.IScreenServices;
using TriggerValoran.Interface.ISleepServices;
using TriggerValoran.Interface.ITriggerServices;
using TriggerValoran.Model.Color;
using TriggerValoran.Model.Color.PurpleColor;
using TriggerValoran.Model.Color.RedColor;
using TriggerValoran.Model.Color.YellowColor;
using TriggerValoran.Model.DataStateUser;
using TriggerValoran.Model.TriggerSettings;
using TriggerValoran.Model.TriggerSettings.SettingsButton;
using TriggerValoran.Service.ButtonServices;
using TriggerValoran.Service.ColorServices;
using TriggerValoran.Service.EvenServices;
using TriggerValoran.Service.HttpServices;
using TriggerValoran.Service.HttpServices.HttpServicesRequest;
using TriggerValoran.Service.JsonServices;
using TriggerValoran.Service.ScreenServices;
using TriggerValoran.Service.SleepServices;
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
    private IJsonServices<TriggerSettings> _tJsonServices;
    private IJsonServices<Dictionary<string, byte>> _bJsonServices;
    private IJsonServices<DataStateUser?> _gJsonServices;
    private ISleepServices _sleepServices;
    private IHttpServices _httpServices;
    private IHttpServicesRequest _httpServicesRequest;
    private HttpClient _httpClient;
    private HttpRequestMessage _httpRequestMessage;
    private HttpResponseMessage _httpResponseMessage;
    private Color _purpleColor;
    private RedColor _redColor;
    private YellowColor _yellowColor;

    private int _boxY;
    private int _boxX;
    private int _sleepRepeatTime;
    private int _sleepOneTime;
    private string _boxColor = "Purple";
    private int _countFire = 2;
    private bool _isSitDown;
    private bool _isWalkStop;
    private string _start;
    private string _sitdown;
    private string _fire;
    private List<string> _move;
    private DataStateUser? _dataStateUser;

    public MainWindow()
    {
        InitializeComponent();
        if (_triggerServices == null)
        {
            _yellowColor = new YellowColor();
            _redColor = new RedColor();
            _purpleColor = new PurpleColor();
            _httpClient = new HttpClient();
            _httpRequestMessage = new HttpRequestMessage();
            _httpResponseMessage = new HttpResponseMessage();
            _gJsonServices = new JsonServices<DataStateUser?>();
            _httpServicesRequest = new HttpServicesRequest(_httpClient, _httpRequestMessage, _httpResponseMessage);
            _httpServices = new HttpServices(_httpServicesRequest);
            _sleepServices = new SleepServices();
            _buttonServices = new ButtonServices(_sleepServices);
            _colorServices = new ColorServices(_purpleColor, _yellowColor, _redColor);
            _evenServices = new EvenServices(_buttonServices);
            _screenServices = new ScreenServices();
            _tJsonServices = new JsonServices<TriggerSettings>();
            _bJsonServices = new JsonServices<Dictionary<string, byte>>();
            _triggerServices =
                new TriggerServices(new WorkWithServices(_colorServices, _evenServices, _screenServices,
                        _tJsonServices, _bJsonServices, _gJsonServices, _httpServices),
                    new TriggerSettings(_countFire, _boxX, _boxY, _sleepRepeatTime, _sleepOneTime, _boxColor,
                        _isSitDown,
                        _isWalkStop, new SettingsButton(_start, _fire, _sitdown, _move)));
        }

        Task.Run(Start);
    }

    private void Start()
    {
        _triggerServices.Trigger();
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
        _triggerServices.Save();
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