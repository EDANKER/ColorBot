﻿using System.Net.Http;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using TriggerValoran.Abstract.Color;
using TriggerValoran.Interface.IColorServices;
using TriggerValoran.Interface.IEvenClickServices;
using TriggerValoran.Interface.IHttpServices;
using TriggerValoran.Interface.IHttpServicesRequest;
using TriggerValoran.Interface.IJsonServices;
using TriggerValoran.Interface.IMemoryButtonServices;
using TriggerValoran.Interface.IScreenServices;
using TriggerValoran.Interface.ISleepServices;
using TriggerValoran.Interface.ITriggerServices;
using TriggerValoran.Model.Color.PurpleColor;
using TriggerValoran.Model.Color.RedColor;
using TriggerValoran.Model.Color.YellowColor;
using TriggerValoran.Model.DataStateUser;
using TriggerValoran.Model.Settings.SettingsButton;
using TriggerValoran.Model.Settings.TriggerSettings;
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
    private readonly IButtonServices _buttonServices;
    private readonly ITriggerServices _triggerServices;
    private readonly IColorServices _colorServices;
    private readonly IEvenServices _evenServices;
    private readonly IScreenServices _screenServices;
    private readonly IJsonServices<TriggerSettings> _tJsonServices;
    private readonly IJsonServices<Dictionary<string, byte>> _bJsonServices;
    private readonly IJsonServices<DataStateUser?> _gJsonServices;
    private readonly ISleepServices _sleepServices;
    private readonly IHttpServices _httpServices;
    private readonly IHttpServicesRequest _httpServicesRequest;
    private readonly HttpClient _httpClient;
    private readonly HttpRequestMessage _httpRequestMessage;
    private readonly HttpResponseMessage _httpResponseMessage;
    private readonly Color _purpleColor;
    private readonly Color _redColor;
    private readonly Color _yellowColor;

    private int _boxY = 10;
    private int _boxX = 10;
    private int _sleepTime;
    private string _boxColor = "Purple";
    private int _countFire = 2;
    private bool _isSitDown;
    private bool _isWalkStop;
    private string _start = "Shift";
    private string _sitDown = "Ctrl";
    private string _fire = "V";
    private List<string> _move = new();
    private string _stateStart = "По нажатию";

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
                    _tJsonServices, _bJsonServices, _gJsonServices, _httpServices));
        }

        Update();
        Task.Run(Start);
    }

    private TriggerSettings Update()
    {
        return new TriggerSettings(_countFire, _boxX, _boxY, _sleepTime, _boxColor,
            _isSitDown,
            _isWalkStop, new SettingsButton(_start, _fire, _sitDown, _move), _stateStart);
    }

    private void Start()
    {
        if (_triggerServices.SaveButton())
        {
            while (true)
            {
                _triggerServices.Trigger(Update());
            }
        }

        throw new Exception();
    }

    private void BoxX(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        TextX.Text = $"Box по X {e.NewValue.ToString("0")}px";
        BoxRad.Width = _boxX = (int)e.NewValue;
    }

    private void BoxY(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        TextY.Text = $"Box по Y {e.NewValue.ToString("0")}px";
        BoxRad.Height = _boxY = (int)e.NewValue;
    }

    private void SleepOneFire(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        TextSleepFire.Text = $"Выстрел черещ {e.NewValue.ToString("0")} с";
        _sleepTime = (int)e.NewValue;
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
        NameItemCountFire.Content = "3" + " выстрела";
        _countFire = 3;
        CountFire.IsOpen = false;
    }

    private void Count1(object sender, RoutedEventArgs e)
    {
        NameItemCountFire.Content = "1" + " выстрела";
        _countFire = 1;
        CountFire.IsOpen = false;
    }

    private void Count2(object sender, RoutedEventArgs e)
    {
        NameItemCountFire.Content = "2" + " выстрела";
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
        _triggerServices.SaveSettings(Update());
    }

    private void Get(object sender, RoutedEventArgs e)
    {
        TriggerSettings jTriggerSettings = _triggerServices.GetSaveSettings();
        _countFire = jTriggerSettings.Count;
        _boxX = jTriggerSettings.BoxSizeX;
        SliderY.Value = _boxY = jTriggerSettings.BoxSizeY;
        _sleepTime = jTriggerSettings.SleepTime;
        _boxColor = jTriggerSettings.BoxColor;
        _isSitDown = jTriggerSettings.SitDown;
        _isWalkStop = jTriggerSettings.WalkStop;
        SliderX.Value = _boxX;
        NameItemCountFire.Content = _countFire + " выстрела";
        IsSitDown.IsChecked = _isSitDown;
        IsWalkStop.IsChecked = _isWalkStop;
        SliderTimeFire.Value = _sleepTime;
        BindItem.Content = _stateStart = jTriggerSettings.StateStart;
        GetColor();
    }

    private void GetColor()
    {
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

    private void OpenStateStart(object sender, RoutedEventArgs e)
    {
        Bind.IsOpen = true;
    }

    private void Click(object sender, RoutedEventArgs e)
    {
        Bind.IsOpen = false;
        _stateStart = "По нажатию";
        BindItem.Content = "По нажатию";
    }

    private void Cycle(object sender, RoutedEventArgs e)
    {
        Bind.IsOpen = false;
        _stateStart = "Постоянно";
        BindItem.Content = "Постоянно";
    }

    private void ActiveTrigger(object sender, RoutedEventArgs e)
    {
        /*
            _start = _triggerServices.SelectButton();
            BindActiveTrigger.Content = _triggerServices.SelectButton();
        */
    }

    private void SitDownTrigger(object sender, RoutedEventArgs e)
    {
        /*
            _sitDown = _triggerServices.SelectButton();
            BindSitDownTrigger.Content = _triggerServices.SelectButton();
        */
    }

    private void FireTrigger(object sender, RoutedEventArgs e)
    {
        /*
            _fire = _triggerServices.SelectButton();
            BindFireTrigger.Content = _triggerServices.SelectButton();
        */
    }

    private void Close(object sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
    }

    private void WinMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            DragMove();
        }
    }
}