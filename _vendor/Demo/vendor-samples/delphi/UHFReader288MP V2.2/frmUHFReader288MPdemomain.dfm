object frmUHFReader288MPmain: TfrmUHFReader288MPmain
  Left = 370
  Top = 78
  BorderIcons = [biSystemMenu, biMinimize]
  BorderStyle = bsSingle
  Caption = 'UHFReader288MP Demo V2.2'
  ClientHeight = 704
  ClientWidth = 792
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  OnCloseQuery = FormCloseQuery
  OnCreate = FormCreate
  OnDestroy = FormDestroy
  PixelsPerInch = 96
  TextHeight = 13
  object PageControl1: TPageControl
    Left = 0
    Top = 0
    Width = 786
    Height = 681
    ActivePage = TabSheet2
    TabOrder = 0
    OnChange = PageControl1Change
    object TabSheet1: TTabSheet
      Caption = 'Reader Parameter'
      object GroupBox_ReaderInfo: TGroupBox
        Left = 136
        Top = 10
        Width = 633
        Height = 102
        Caption = 'Reader Information'
        TabOrder = 0
        object Label2: TLabel
          Left = 162
          Top = 18
          Width = 38
          Height = 13
          Caption = 'Version:'
        end
        object Label3: TLabel
          Left = 10
          Top = 47
          Width = 50
          Height = 13
          Caption = 'Address'#65306
        end
        object Label4: TLabel
          Left = 328
          Top = 47
          Width = 92
          Height = 13
          Caption = 'Max-Inventory-time:'
        end
        object Label10: TLabel
          Left = 10
          Top = 18
          Width = 27
          Height = 13
          Caption = 'Type:'
        end
        object Label11: TLabel
          Left = 328
          Top = 18
          Width = 36
          Height = 13
          Caption = 'Protocl:'
        end
        object Label8: TLabel
          Left = 160
          Top = 47
          Width = 33
          Height = 13
          Caption = 'Power:'
        end
        object Label13: TLabel
          Left = 160
          Top = 76
          Width = 51
          Height = 13
          Caption = 'Dmaxfre'#65306
        end
        object Label14: TLabel
          Left = 10
          Top = 76
          Width = 39
          Height = 13
          Caption = 'Dminfre:'
        end
        object Edit_Version: TEdit
          Left = 225
          Top = 14
          Width = 96
          Height = 21
          Color = clSilver
          ImeName = #20013#25991' ('#31616#20307') - '#24494#36719#25340#38899
          ReadOnly = True
          TabOrder = 1
        end
        object Edit_ComAdr: TEdit
          Left = 72
          Top = 43
          Width = 81
          Height = 21
          Color = clSilver
          ImeName = #20013#25991' ('#31616#20307') - '#24494#36719#25340#38899
          ReadOnly = True
          TabOrder = 3
        end
        object Edit_scantime: TEdit
          Left = 488
          Top = 43
          Width = 129
          Height = 21
          Color = clSilver
          ImeName = #20013#25991' ('#31616#20307') - '#24494#36719#25340#38899
          ReadOnly = True
          TabOrder = 5
        end
        object Edit_Type: TEdit
          Left = 48
          Top = 14
          Width = 105
          Height = 21
          Color = clSilver
          ImeName = #20013#25991' ('#31616#20307') - '#24494#36719#25340#38899
          ReadOnly = True
          TabOrder = 0
        end
        object Button3: TButton
          Left = 488
          Top = 69
          Width = 129
          Height = 25
          Action = Action_GetReaderInformation
          TabOrder = 6
        end
        object Edit_dmaxfre: TEdit
          Left = 225
          Top = 72
          Width = 96
          Height = 21
          Color = clSilver
          ImeName = #20013#25991' ('#31616#20307') - '#24494#36719#25340#38899
          ReadOnly = True
          TabOrder = 8
        end
        object Edit_dminfre: TEdit
          Left = 72
          Top = 72
          Width = 81
          Height = 21
          Color = clSilver
          ImeName = #20013#25991' ('#31616#20307') - '#24494#36719#25340#38899
          ReadOnly = True
          TabOrder = 7
        end
        object Edit_power: TEdit
          Left = 225
          Top = 43
          Width = 96
          Height = 21
          Color = clSilver
          ImeName = #20013#25991' ('#31616#20307') - '#24494#36719#25340#38899
          ReadOnly = True
          TabOrder = 4
        end
        object EPCC1G2: TCheckBox
          Left = 488
          Top = 25
          Width = 73
          Height = 17
          BiDiMode = bdLeftToRight
          Caption = 'EPCC1-G2'
          ParentBiDiMode = False
          TabOrder = 2
        end
        object ISO180006B: TCheckBox
          Left = 488
          Top = 8
          Width = 89
          Height = 17
          BiDiMode = bdLeftToRight
          Caption = 'ISO18000-6B'
          ParentBiDiMode = False
          TabOrder = 9
        end
      end
      object GroupBox2: TGroupBox
        Left = 136
        Top = 113
        Width = 633
        Height = 148
        Caption = 'Set Reader Parameter'
        TabOrder = 1
        object Label15: TLabel
          Left = 8
          Top = 88
          Width = 39
          Height = 13
          Caption = 'Dminfre:'
        end
        object Label16: TLabel
          Left = 8
          Top = 119
          Width = 51
          Height = 13
          Caption = 'Dmaxfre'#65306
        end
        object Label17: TLabel
          Left = 234
          Top = 24
          Width = 51
          Height = 13
          Caption = 'BaudRate:'
        end
        object Label1: TLabel
          Left = 8
          Top = 26
          Width = 69
          Height = 13
          Caption = 'Address(HEX):'
        end
        object Label7: TLabel
          Left = 8
          Top = 57
          Width = 33
          Height = 13
          Caption = 'Power:'
        end
        object Label5: TLabel
          Left = 234
          Top = 57
          Width = 92
          Height = 13
          Caption = 'Max-Inventory-time:'
        end
        object Button5: TButton
          Left = 206
          Top = 113
          Width = 111
          Height = 25
          Action = Action_SetReaderInformation
          Caption = 'Set Parameter'
          TabOrder = 6
        end
        object ComboBox_baud: TComboBox
          Left = 331
          Top = 22
          Width = 129
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 1
          Items.Strings = (
            '9600bps'
            '19200bps'
            '38400bps'
            '57600bps'
            '115200bps')
        end
        object Edit_NewComAdr: TEdit
          Left = 80
          Top = 22
          Width = 113
          Height = 21
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          MaxLength = 2
          TabOrder = 0
          Text = '00'
          OnKeyPress = Edit_WriteDataKeyPress
        end
        object ComboBox_scantime: TComboBox
          Left = 331
          Top = 53
          Width = 129
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' ('#31616#20307') - '#24494#36719#25340#38899
          ItemHeight = 13
          TabOrder = 3
        end
        object Button1: TButton
          Left = 330
          Top = 113
          Width = 111
          Height = 25
          Action = Action_SetReaderInformation_0
          Caption = 'Default Parameter'
          TabOrder = 7
        end
        object ComboBox_dminfre: TComboBox
          Left = 80
          Top = 84
          Width = 113
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 4
          OnSelect = ComboBox_dminfreSelect
        end
        object ComboBox_dmaxfre: TComboBox
          Tag = 1
          Left = 80
          Top = 115
          Width = 113
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 8
          OnSelect = ComboBox_dminfreSelect
        end
        object ComboBox_PowerDbm: TComboBox
          Left = 80
          Top = 53
          Width = 113
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 2
          Items.Strings = (
            '0'
            '1'
            '2'
            '3'
            '4'
            '5'
            '6'
            '7'
            '8'
            '9'
            '10'
            '11'
            '12'
            '13'
            '14'
            '15'
            '16'
            '17'
            '18'
            '19'
            '20'
            '21'
            '22'
            '23'
            '24'
            '25'
            '26'
            '27'
            '28'
            '29'
            '30')
        end
        object CheckBox_SameFre: TCheckBox
          Left = 202
          Top = 88
          Width = 81
          Height = 17
          Caption = 'Single Freq'
          TabOrder = 5
          OnClick = CheckBox_SameFreClick
        end
        object GroupBox7: TGroupBox
          Left = 464
          Top = 11
          Width = 153
          Height = 127
          Caption = 'Band'
          TabOrder = 9
          object RadioButton_band2: TRadioButton
            Left = 8
            Top = 33
            Width = 113
            Height = 17
            Caption = 'Chinese band2'
            TabOrder = 0
            OnClick = RadioButton_band2Click
          end
          object RadioButton_band3: TRadioButton
            Left = 8
            Top = 50
            Width = 113
            Height = 17
            Caption = 'US band'
            TabOrder = 1
            OnClick = RadioButton_band3Click
          end
          object RadioButton_band4: TRadioButton
            Left = 8
            Top = 65
            Width = 113
            Height = 17
            Caption = 'Korean band'
            TabOrder = 2
            OnClick = RadioButton_band4Click
          end
          object RadioButton_band5: TRadioButton
            Left = 8
            Top = 82
            Width = 113
            Height = 17
            Caption = 'EU band'
            TabOrder = 3
            OnClick = RadioButton_band5Click
          end
          object RadioButton_band1: TRadioButton
            Left = 8
            Top = 15
            Width = 113
            Height = 17
            Caption = 'Chinese band1'
            TabOrder = 4
            OnClick = RadioButton_band1Click
          end
          object RadioButton_band12: TRadioButton
            Left = 8
            Top = 100
            Width = 113
            Height = 17
            Caption = 'US band3'
            TabOrder = 5
            OnClick = RadioButton_band12Click
          end
        end
      end
      object GroupBox28: TGroupBox
        Left = 456
        Top = 268
        Width = 313
        Height = 47
        Caption = 'Set Notification Pulse Output'
        TabOrder = 2
        object Check_out1: TCheckBox
          Left = 6
          Top = 21
          Width = 49
          Height = 17
          Caption = 'OUT1'
          TabOrder = 0
        end
        object Check_out2: TCheckBox
          Left = 57
          Top = 20
          Width = 49
          Height = 17
          Caption = 'OUT2'
          TabOrder = 1
        end
        object Check_out3: TCheckBox
          Left = 108
          Top = 20
          Width = 48
          Height = 17
          Caption = 'OUT3'
          TabOrder = 2
        end
        object Check_out4: TCheckBox
          Left = 160
          Top = 20
          Width = 48
          Height = 17
          Caption = 'OUT4'
          TabOrder = 3
        end
        object Button_OutputRep: TButton
          Left = 229
          Top = 14
          Width = 68
          Height = 25
          Caption = 'Set'
          TabOrder = 4
          OnClick = Button_OutputRepClick
        end
      end
      object GroupBox29: TGroupBox
        Left = 136
        Top = 268
        Width = 316
        Height = 47
        Caption = 'Relay control '
        TabOrder = 3
        object Label45: TLabel
          Left = 12
          Top = 19
          Width = 65
          Height = 13
          Caption = 'ReleaseTime:'
        end
        object Label46: TLabel
          Left = 176
          Top = 18
          Width = 29
          Height = 13
          Caption = '*50ms'
        end
        object ComboBox_RelayTime: TComboBox
          Left = 74
          Top = 13
          Width = 100
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 0
        end
        object Button_RelayTime: TButton
          Left = 228
          Top = 11
          Width = 70
          Height = 25
          Caption = 'Set'
          TabOrder = 1
          OnClick = Button_RelayTimeClick
        end
      end
      object GroupBox43: TGroupBox
        Left = 0
        Top = 10
        Width = 134
        Height = 355
        Caption = 'Communication'
        TabOrder = 4
        object RadioButton13: TRadioButton
          Left = 9
          Top = 16
          Width = 52
          Height = 17
          Caption = 'COM'
          TabOrder = 0
          OnClick = RadioButton13Click
        end
        object RadioButton14: TRadioButton
          Left = 65
          Top = 16
          Width = 60
          Height = 17
          Caption = 'TCP/IP'
          TabOrder = 1
          OnClick = RadioButton14Click
        end
        object GroupBox_COM: TGroupBox
          Left = 8
          Top = 30
          Width = 117
          Height = 161
          Caption = 'COM'
          TabOrder = 2
          object Label6: TLabel
            Left = 12
            Top = 14
            Width = 22
            Height = 13
            Caption = 'Port:'
          end
          object Label49: TLabel
            Left = 13
            Top = 56
            Width = 51
            Height = 13
            Caption = 'BaudRate:'
          end
          object ComboBox_COM: TComboBox
            Left = 40
            Top = 9
            Width = 64
            Height = 21
            Style = csDropDownList
            ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
            ItemHeight = 13
            TabOrder = 0
            OnChange = ComboBox_COMChange
          end
          object Button2: TButton
            Left = 12
            Top = 98
            Width = 92
            Height = 22
            Caption = 'Open Com Port'
            TabOrder = 3
            OnClick = Button2Click
          end
          object Button4: TButton
            Left = 12
            Top = 131
            Width = 92
            Height = 21
            Caption = 'Close COM Port'
            TabOrder = 4
            OnClick = Button4Click
          end
          object StaticText1: TStaticText
            Left = 13
            Top = 35
            Width = 45
            Height = 17
            Caption = 'Address:'
            TabOrder = 2
          end
          object Edit_CmdComAddr: TEdit
            Left = 64
            Top = 32
            Width = 37
            Height = 21
            CharCase = ecUpperCase
            ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
            MaxLength = 2
            TabOrder = 1
            Text = 'FF'
            OnKeyPress = Edit_WriteDataKeyPress
          end
          object ComboBox_baud2: TComboBox
            Left = 12
            Top = 70
            Width = 94
            Height = 21
            Style = csDropDownList
            ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
            ItemHeight = 13
            TabOrder = 5
            Items.Strings = (
              '9600bps'
              '19200bps'
              '38400bps'
              '57600bps'
              '115200bps')
          end
        end
        object GroupBox44: TGroupBox
          Left = 7
          Top = 193
          Width = 118
          Height = 157
          Caption = 'TCP/IP'
          TabOrder = 3
          object Label66: TLabel
            Left = 12
            Top = 19
            Width = 22
            Height = 13
            Caption = 'Port:'
          end
          object Label67: TLabel
            Left = 12
            Top = 48
            Width = 13
            Height = 13
            Caption = 'IP:'
          end
          object Label68: TLabel
            Left = 12
            Top = 74
            Width = 41
            Height = 13
            Caption = 'Address:'
          end
          object Edit12: TEdit
            Left = 48
            Top = 14
            Width = 58
            Height = 21
            ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
            TabOrder = 0
            Text = '27011'
          end
          object Edit13: TEdit
            Left = 32
            Top = 40
            Width = 74
            Height = 21
            ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
            TabOrder = 1
            Text = '192.168.0.250'
          end
          object Edit14: TEdit
            Left = 67
            Top = 66
            Width = 36
            Height = 21
            ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
            TabOrder = 2
            Text = 'FF'
          end
          object opnet: TButton
            Left = 8
            Top = 94
            Width = 99
            Height = 25
            Caption = 'Open Net Port'
            Enabled = False
            TabOrder = 3
            OnClick = opnetClick
          end
          object closenet: TButton
            Left = 8
            Top = 126
            Width = 99
            Height = 25
            Caption = 'Close Net Port'
            Enabled = False
            TabOrder = 4
            OnClick = closenetClick
          end
        end
      end
      object GroupBox45: TGroupBox
        Left = 0
        Top = 366
        Width = 132
        Height = 86
        Caption = 'Reader serial number'
        TabOrder = 5
        object Edit15: TEdit
          Left = 9
          Top = 25
          Width = 115
          Height = 21
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          TabOrder = 0
          OnKeyPress = Edit_WriteDataKeyPress
        end
        object Button8: TButton
          Left = 53
          Top = 52
          Width = 71
          Height = 25
          Caption = 'Get'
          TabOrder = 1
          OnClick = Button8Click
        end
      end
      object Group_Fenti: TGroupBox
        Left = 136
        Top = 317
        Width = 634
        Height = 40
        Caption = 'GPIO Operation'
        TabOrder = 6
        object Button_SetGPIO: TButton
          Left = 461
          Top = 10
          Width = 74
          Height = 25
          Caption = 'Set'
          TabOrder = 0
          OnClick = Button_SetGPIOClick
        end
        object Button_GetGPIO: TButton
          Left = 544
          Top = 10
          Width = 73
          Height = 25
          Caption = 'Get'
          TabOrder = 1
          OnClick = Button_GetGPIOClick
        end
        object COUT1: TCheckBox
          Left = 6
          Top = 16
          Width = 49
          Height = 17
          Caption = 'OUT1'
          TabOrder = 2
        end
        object COUT2: TCheckBox
          Left = 56
          Top = 15
          Width = 49
          Height = 17
          Caption = 'OUT2'
          TabOrder = 3
        end
        object CINT1: TCheckBox
          Left = 215
          Top = 15
          Width = 49
          Height = 17
          Caption = 'INT1'
          Enabled = False
          TabOrder = 4
        end
        object CINT2: TCheckBox
          Left = 269
          Top = 15
          Width = 49
          Height = 17
          Caption = 'INT2'
          Enabled = False
          TabOrder = 5
        end
      end
      object grp_bufflen: TGroupBox
        Left = 136
        Top = 360
        Width = 313
        Height = 41
        Caption = 'Buffer Save Length'
        TabOrder = 7
        object rb128: TRadioButton
          Left = 8
          Top = 18
          Width = 65
          Height = 17
          Caption = '128bit'
          Checked = True
          TabOrder = 0
          TabStop = True
        end
        object rb496: TRadioButton
          Left = 72
          Top = 18
          Width = 65
          Height = 17
          Caption = '496bit'
          TabOrder = 1
        end
        object btSetSaveLen: TButton
          Left = 144
          Top = 11
          Width = 75
          Height = 25
          Caption = 'Set'
          TabOrder = 2
          OnClick = btSetSaveLenClick
        end
        object btGetSaveLen: TButton
          Left = 227
          Top = 10
          Width = 75
          Height = 25
          Caption = 'Get'
          TabOrder = 3
          OnClick = btGetSaveLenClick
        end
      end
      object grp_antconfig: TGroupBox
        Left = 135
        Top = 468
        Width = 314
        Height = 42
        Caption = 'Antenna configuration '
        TabOrder = 8
        object Button_Ant: TButton
          Left = 236
          Top = 12
          Width = 63
          Height = 24
          Caption = 'Set'
          TabOrder = 0
          OnClick = Button_AntClick
        end
        object cant4: TCheckBox
          Left = 174
          Top = 17
          Width = 55
          Height = 17
          Caption = 'ANT4'
          TabOrder = 1
        end
        object cant3: TCheckBox
          Left = 117
          Top = 17
          Width = 55
          Height = 17
          Caption = 'ANT3'
          TabOrder = 2
        end
        object cant2: TCheckBox
          Left = 62
          Top = 17
          Width = 54
          Height = 17
          Caption = 'ANT2'
          TabOrder = 3
        end
        object cant1: TCheckBox
          Left = 6
          Top = 18
          Width = 55
          Height = 17
          Caption = 'ANT1'
          TabOrder = 4
        end
      end
      object grp_checkant: TGroupBox
        Left = 136
        Top = 402
        Width = 313
        Height = 65
        Caption = 'Antenna Checked'
        TabOrder = 9
        object OpenANT: TRadioButton
          Left = 6
          Top = 18
          Width = 225
          Height = 17
          Caption = 'Enable antenna detection'
          Checked = True
          TabOrder = 0
          TabStop = True
        end
        object CloseANT: TRadioButton
          Left = 6
          Top = 43
          Width = 226
          Height = 17
          Caption = 'Disable antenna detection'
          TabOrder = 1
        end
        object Button6: TButton
          Left = 225
          Top = 31
          Width = 75
          Height = 25
          Caption = 'Set'
          TabOrder = 2
          OnClick = Button6Click
        end
      end
      object GroupBox8: TGroupBox
        Left = 457
        Top = 360
        Width = 312
        Height = 42
        Caption = 'Beep Operation'
        TabOrder = 10
        object Radio_beepEn: TRadioButton
          Left = 16
          Top = 16
          Width = 49
          Height = 17
          Caption = 'Open'
          TabOrder = 0
        end
        object Radio_beepDis: TRadioButton
          Left = 96
          Top = 16
          Width = 49
          Height = 17
          Caption = 'Close'
          TabOrder = 1
        end
        object Button_Beep: TButton
          Left = 224
          Top = 11
          Width = 71
          Height = 25
          Caption = 'Set'
          TabOrder = 2
          OnClick = Button_BeepClick
        end
      end
      object GroupBox22: TGroupBox
        Left = 455
        Top = 402
        Width = 314
        Height = 63
        Caption = 'Write Power operation'
        TabOrder = 11
        object Label36: TLabel
          Left = 82
          Top = 39
          Width = 21
          Height = 13
          Caption = 'dBm'
        end
        object rb_Dwp: TRadioButton
          Left = 8
          Top = 16
          Width = 113
          Height = 17
          Caption = 'Disable'
          TabOrder = 0
        end
        object rb_Ewp: TRadioButton
          Left = 136
          Top = 16
          Width = 113
          Height = 17
          Caption = 'Enable'
          TabOrder = 1
        end
        object Com_wp: TComboBox
          Left = 16
          Top = 34
          Width = 65
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 2
          Items.Strings = (
            '0'
            '1'
            '2'
            '3'
            '4'
            '5'
            '6'
            '7'
            '8'
            '9'
            '10'
            '11'
            '12'
            '13'
            '14'
            '15'
            '16'
            '17'
            '18'
            '19'
            '20'
            '21'
            '22'
            '23'
            '24'
            '25'
            '26'
            '27'
            '28'
            '29'
            '30')
        end
        object bt_SetWp: TButton
          Left = 144
          Top = 33
          Width = 74
          Height = 25
          Caption = 'Set'
          TabOrder = 3
          OnClick = bt_SetWpClick
        end
        object bt_GetWp: TButton
          Left = 225
          Top = 32
          Width = 73
          Height = 25
          Caption = 'Get'
          TabOrder = 4
          OnClick = bt_GetWpClick
        end
      end
      object GroupBox57: TGroupBox
        Left = 455
        Top = 467
        Width = 314
        Height = 47
        Caption = 'Write retry operation'
        TabOrder = 12
        object com_retry: TComboBox
          Left = 15
          Top = 17
          Width = 66
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 0
          Items.Strings = (
            '0'
            '1'
            '2'
            '3'
            '4'
            '5'
            '6'
            '7')
        end
        object bt_Setretry: TButton
          Left = 144
          Top = 14
          Width = 74
          Height = 25
          Caption = 'Set'
          TabOrder = 1
          OnClick = bt_SetretryClick
        end
        object bt_Getretry: TButton
          Left = 225
          Top = 14
          Width = 73
          Height = 25
          Caption = 'Get'
          TabOrder = 2
          OnClick = bt_GetretryClick
        end
      end
      object GroupBox64: TGroupBox
        Left = 136
        Top = 512
        Width = 313
        Height = 41
        Caption = 'DRM Status'
        TabOrder = 13
        object rbRB_OPEN: TRadioButton
          Left = 8
          Top = 18
          Width = 65
          Height = 17
          Caption = 'Open'
          TabOrder = 0
        end
        object rbRB_CLOSE: TRadioButton
          Left = 72
          Top = 18
          Width = 65
          Height = 17
          Caption = 'Close'
          TabOrder = 1
        end
        object btnSetDRM: TButton
          Left = 144
          Top = 11
          Width = 75
          Height = 25
          Caption = 'Set'
          TabOrder = 2
          OnClick = btnSetDRMClick
        end
        object btnGetDRM: TButton
          Left = 227
          Top = 10
          Width = 75
          Height = 25
          Caption = 'Get'
          TabOrder = 3
          OnClick = btnGetDRMClick
        end
      end
      object GroupBox65: TGroupBox
        Left = 456
        Top = 517
        Width = 313
        Height = 51
        Caption = 'Measuring antenna ports return loss'
        TabOrder = 14
        object Label12: TLabel
          Left = 5
          Top = 24
          Width = 17
          Height = 13
          Caption = 'RL:'
        end
        object Label117: TLabel
          Left = 73
          Top = 24
          Width = 11
          Height = 13
          Caption = '@'
        end
        object Label118: TLabel
          Left = 154
          Top = 24
          Width = 22
          Height = 13
          Caption = 'MHz'
        end
        object textReturnLoss: TEdit
          Left = 24
          Top = 20
          Width = 46
          Height = 21
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ReadOnly = True
          TabOrder = 0
        end
        object cmbReturnLossFreq: TComboBox
          Left = 88
          Top = 20
          Width = 63
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 1
        end
        object cbbAnt: TComboBox
          Left = 179
          Top = 20
          Width = 64
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 2
          Items.Strings = (
            'ANT1'
            'ANT2'
            'ANT3'
            'ANT4')
        end
        object btReturnLoss: TButton
          Left = 244
          Top = 18
          Width = 63
          Height = 24
          Caption = 'Get'
          TabOrder = 3
          OnClick = btReturnLossClick
        end
      end
      object GroupBox66: TGroupBox
        Left = 136
        Top = 556
        Width = 313
        Height = 43
        Caption = 'Temperature measurement'#10
        TabOrder = 15
        object btnGetReaderTemperature: TButton
          Left = 227
          Top = 10
          Width = 75
          Height = 25
          Caption = 'Get'
          TabOrder = 0
          OnClick = btnGetReaderTemperatureClick
        end
        object txtReaderTemperature: TEdit
          Left = 20
          Top = 15
          Width = 121
          Height = 21
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ReadOnly = True
          TabOrder = 1
        end
      end
    end
    object TabSheet_Real: TTabSheet
      Caption = 'Real_time-Inventory'
      ImageIndex = 7
      object SpeedButton2: TSpeedButton
        Left = 556
        Top = 626
        Width = 104
        Height = 25
        AllowAllUp = True
        GroupIndex = 5
        Caption = 'Get'
        OnClick = SpeedButton2Click
      end
      object GroupBox12: TGroupBox
        Left = 4
        Top = 2
        Width = 206
        Height = 49
        Caption = 'Protocl'
        TabOrder = 0
        object rbm_G2: TRadioButton
          Left = 6
          Top = 16
          Width = 83
          Height = 17
          Caption = 'EPCC1-G2'
          Checked = True
          TabOrder = 0
          TabStop = True
        end
        object rbm_6B: TRadioButton
          Left = 97
          Top = 16
          Width = 90
          Height = 17
          Caption = '18000-6B'
          TabOrder = 1
        end
      end
      object GroupBox26: TGroupBox
        Left = 215
        Top = 2
        Width = 154
        Height = 49
        Caption = 'Inventory Interval'
        TabOrder = 1
        object Label94: TLabel
          Left = 8
          Top = 21
          Width = 55
          Height = 13
          Caption = 'Pulse Time:'
        end
        object COM_MRPTime: TComboBox
          Left = 71
          Top = 16
          Width = 72
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 0
          Items.Strings = (
            '10ms'
            '20ms'
            '30ms'
            '50ms'
            '100ms')
        end
      end
      object GroupBox52: TGroupBox
        Left = 374
        Top = 3
        Width = 154
        Height = 49
        Caption = 'Tag Filter'
        TabOrder = 2
        object Label95: TLabel
          Left = 8
          Top = 21
          Width = 51
          Height = 13
          Caption = 'Filter Time:'
        end
        object com_MFliterTime: TComboBox
          Left = 71
          Top = 16
          Width = 72
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 0
        end
      end
      object GroupBox53: TGroupBox
        Left = 533
        Top = 3
        Width = 244
        Height = 49
        Caption = 'Query Parameter'
        TabOrder = 3
        object Label96: TLabel
          Left = 8
          Top = 21
          Width = 11
          Height = 13
          Caption = 'Q:'
        end
        object Label97: TLabel
          Left = 123
          Top = 21
          Width = 49
          Height = 13
          Caption = 'Session'#65306
        end
        object com_MQ: TComboBox
          Left = 31
          Top = 16
          Width = 72
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 0
          Items.Strings = (
            '0'
            '1'
            '2'
            '3'
            '4'
            '5'
            '6'
            '7'
            '8'
            '9'
            '10'
            '11'
            '12'
            '13'
            '14'
            '15')
        end
        object com_MS: TComboBox
          Left = 167
          Top = 16
          Width = 72
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 1
          Items.Strings = (
            'S0'
            'S1'
            'S2'
            'S3'
            'AUTO')
        end
      end
      object GroupBox54: TGroupBox
        Left = 3
        Top = 53
        Width = 313
        Height = 92
        Caption = 'Mask'
        TabOrder = 4
        object Label98: TLabel
          Left = 7
          Top = 40
          Width = 100
          Height = 13
          Caption = 'Start Address(Hex)'#65306
        end
        object Label99: TLabel
          Left = 183
          Top = 40
          Width = 61
          Height = 13
          Caption = 'Length(Hex):'
        end
        object Label100: TLabel
          Left = 7
          Top = 70
          Width = 51
          Height = 13
          Caption = 'Data(Hex):'
        end
        object rbm_epc: TRadioButton
          Left = 7
          Top = 16
          Width = 66
          Height = 17
          Caption = 'EPC'
          Checked = True
          TabOrder = 0
          TabStop = True
        end
        object rbm_tid: TRadioButton
          Left = 72
          Top = 16
          Width = 65
          Height = 17
          Caption = 'TID'
          TabOrder = 1
        end
        object rbm_user: TRadioButton
          Left = 136
          Top = 16
          Width = 65
          Height = 17
          Caption = 'User'
          TabOrder = 2
        end
        object txt_maddr: TEdit
          Left = 109
          Top = 35
          Width = 53
          Height = 21
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          MaxLength = 4
          TabOrder = 3
          Text = '0000'
          OnKeyPress = Edit2KeyPress
        end
        object txt_mlen: TEdit
          Left = 259
          Top = 33
          Width = 47
          Height = 21
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          MaxLength = 2
          TabOrder = 4
          Text = '00'
          OnKeyPress = Edit2KeyPress
        end
        object txt_mdata: TEdit
          Left = 64
          Top = 64
          Width = 241
          Height = 21
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          TabOrder = 5
          Text = '00'
          OnKeyPress = Edit2KeyPress
        end
        object CheckBox_Mask: TCheckBox
          Left = 208
          Top = 16
          Width = 65
          Height = 17
          Caption = 'Enable'
          TabOrder = 6
        end
      end
      object GroupBox55: TGroupBox
        Left = 320
        Top = 56
        Width = 209
        Height = 89
        Caption = 'Query TID Parameter'
        TabOrder = 5
        object Label101: TLabel
          Left = 8
          Top = 29
          Width = 66
          Height = 13
          Caption = 'Start Address:'
        end
        object Label104: TLabel
          Left = 7
          Top = 61
          Width = 45
          Height = 13
          Caption = 'Length'#65306
        end
        object txt_tidadr: TEdit
          Left = 72
          Top = 21
          Width = 50
          Height = 21
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          MaxLength = 2
          TabOrder = 0
          Text = '02'
          OnKeyPress = Edit2KeyPress
        end
        object txt_tidlen: TEdit
          Left = 71
          Top = 53
          Width = 50
          Height = 21
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          MaxLength = 2
          TabOrder = 1
          Text = '04'
          OnKeyPress = Edit2KeyPress
        end
        object Check_TID: TCheckBox
          Left = 128
          Top = 20
          Width = 65
          Height = 17
          Caption = 'Enable'
          TabOrder = 2
        end
      end
      object GroupBox41: TGroupBox
        Left = 536
        Top = 56
        Width = 241
        Height = 49
        Caption = 'Work Mode Setting'
        TabOrder = 6
        object com_mwork: TComboBox
          Left = 8
          Top = 18
          Width = 145
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 0
          Items.Strings = (
            'Answer Mode'
            'Real-time-Inventory'
            'Trigger Mode')
        end
        object bt_setwork: TButton
          Left = 158
          Top = 15
          Width = 75
          Height = 25
          Action = Action_Real
          Caption = 'Set'
          TabOrder = 1
        end
      end
      object bt_SetParameter: TButton
        Left = 534
        Top = 114
        Width = 116
        Height = 25
        Caption = 'Set Paramerer'
        TabOrder = 7
        OnClick = bt_SetParameterClick
      end
      object bt_GetParameter: TButton
        Left = 658
        Top = 114
        Width = 116
        Height = 25
        Caption = 'Get Parameter'
        TabOrder = 8
        OnClick = bt_GetParameterClick
      end
      object Memo2: TMemo
        Left = 1
        Top = 152
        Width = 774
        Height = 468
        ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
        TabOrder = 9
      end
      object Button40: TButton
        Left = 669
        Top = 626
        Width = 103
        Height = 25
        Caption = 'Clear'
        TabOrder = 10
        OnClick = Button37Click
      end
    end
    object TabSheet_Buff: TTabSheet
      Caption = 'Buffer-Mode'
      ImageIndex = 8
      object Label106: TLabel
        Left = 3
        Top = 96
        Width = 46
        Height = 13
        Caption = 'Tag list'#65306
      end
      object GroupBox56: TGroupBox
        Left = 3
        Top = 1
        Width = 312
        Height = 84
        TabOrder = 0
        object lb_Num: TLabel
          Left = 201
          Top = 23
          Width = 103
          Height = 56
          Alignment = taRightJustify
          AutoSize = False
          BiDiMode = bdLeftToRight
          Caption = '0'
          Color = clWhite
          Font.Charset = ANSI_CHARSET
          Font.Color = clRed
          Font.Height = -56
          Font.Name = #26032#23435#20307
          Font.Style = []
          ParentBiDiMode = False
          ParentColor = False
          ParentFont = False
        end
        object Label105: TLabel
          Left = 202
          Top = 9
          Width = 62
          Height = 13
          Caption = 'Tag Number:'
        end
        object btStartBuffer: TButton
          Left = 12
          Top = 23
          Width = 97
          Height = 41
          Caption = 'Start'
          TabOrder = 0
          OnClick = btStartBufferClick
        end
        object rb_BEPC: TRadioButton
          Left = 120
          Top = 23
          Width = 57
          Height = 17
          Caption = 'EPC'
          Checked = True
          TabOrder = 1
          TabStop = True
        end
        object rb_BTID: TRadioButton
          Left = 120
          Top = 47
          Width = 56
          Height = 17
          Caption = 'TID'
          TabOrder = 2
        end
      end
      object GroupBox58: TGroupBox
        Left = 469
        Top = -2
        Width = 304
        Height = 87
        TabOrder = 1
        object btGetBuffer: TButton
          Left = 16
          Top = 19
          Width = 132
          Height = 25
          Action = Action_Buff
          Caption = 'Read Buffer'
          TabOrder = 0
        end
        object btGetAndClBuffer: TButton
          Left = 160
          Top = 19
          Width = 132
          Height = 25
          Caption = 'Read and clear buffer'
          TabOrder = 1
          OnClick = btGetAndClBufferClick
        end
        object btClearBuffer: TButton
          Left = 16
          Top = 52
          Width = 132
          Height = 25
          Caption = 'Clear Buffer'
          TabOrder = 2
          OnClick = btClearBufferClick
        end
        object btGetBufferNum: TButton
          Left = 160
          Top = 52
          Width = 132
          Height = 25
          Caption = 'Query tag number'
          TabOrder = 3
          OnClick = btGetBufferNumClick
        end
      end
      object btClear: TButton
        Left = 631
        Top = 88
        Width = 129
        Height = 25
        Caption = 'Clear'
        TabOrder = 2
        OnClick = btClearClick
      end
      object ListView3: TListView
        Left = 1
        Top = 115
        Width = 774
        Height = 536
        Columns = <
          item
            Caption = 'No.'
            Width = 70
          end
          item
            Caption = 'EPC/TID'
            Width = 360
          end
          item
            Alignment = taCenter
            Caption = 'Length'
            Width = 80
          end
          item
            Alignment = taCenter
            Caption = 'ANT'
            Width = 80
          end
          item
            Alignment = taCenter
            Caption = 'RSSI'
            Width = 80
          end
          item
            Alignment = taCenter
            Caption = 'Times'
            Width = 80
          end>
        GridLines = True
        TabOrder = 3
        ViewStyle = vsReport
      end
      object GroupBox59: TGroupBox
        Left = 313
        Top = 0
        Width = 157
        Height = 85
        TabOrder = 4
        object Check_BANT1: TCheckBox
          Left = 10
          Top = 24
          Width = 65
          Height = 17
          Caption = 'ANT1'
          TabOrder = 0
        end
        object Check_BANT2: TCheckBox
          Left = 86
          Top = 24
          Width = 65
          Height = 17
          Caption = 'ANT2'
          TabOrder = 1
        end
        object Check_BANT3: TCheckBox
          Left = 10
          Top = 48
          Width = 65
          Height = 17
          Caption = 'ANT3'
          TabOrder = 2
        end
        object Check_BANT4: TCheckBox
          Left = 86
          Top = 48
          Width = 65
          Height = 17
          Caption = 'ANT4'
          TabOrder = 3
        end
      end
    end
    object TabSheet_EPCC1G2: TTabSheet
      Caption = 'EPCC1-G2 Test'
      ImageIndex = 2
      object GroupBox11: TGroupBox
        Left = 8
        Top = 0
        Width = 480
        Height = 272
        Caption = 'List EPC of Tags'
        TabOrder = 0
        object Label79: TLabel
          Left = 11
          Top = 18
          Width = 70
          Height = 13
          Caption = 'Current EPC'#65306
        end
        object Label81: TLabel
          Left = 296
          Top = 26
          Width = 76
          Height = 13
          Caption = 'Total Number'#65306
        end
        object ListView_EPC: TListView
          Left = 8
          Top = 61
          Width = 465
          Height = 204
          Columns = <
            item
              Caption = 'No.'
            end
            item
              Caption = 'EPC/TID'
              Width = 160
            end
            item
              Caption = 'Length'
              Width = 60
            end
            item
              Caption = 'ANT(4,3,2,1)'
              Width = 80
            end
            item
              Caption = 'Times'
            end
            item
              Caption = 'RSSI'
            end>
          GridLines = True
          TabOrder = 0
          ViewStyle = vsReport
        end
        object Edit17: TEdit
          Left = 10
          Top = 33
          Width = 268
          Height = 21
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlue
          Font.Height = -11
          Font.Name = 'MS Sans Serif'
          Font.Style = []
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ParentFont = False
          TabOrder = 1
        end
        object Edit18: TEdit
          Left = 370
          Top = 11
          Width = 102
          Height = 45
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlue
          Font.Height = -32
          Font.Name = 'MS Sans Serif'
          Font.Style = []
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ParentFont = False
          TabOrder = 2
        end
      end
      object GroupBox17: TGroupBox
        Left = 497
        Top = 0
        Width = 281
        Height = 280
        Caption = 'Query Tag'
        TabOrder = 1
        object Label25: TLabel
          Left = 151
          Top = 16
          Width = 67
          Height = 13
          Caption = 'Read Interval:'
        end
        object SpeedButton_Query: TSpeedButton
          Left = 207
          Top = 235
          Width = 66
          Height = 40
          AllowAllUp = True
          GroupIndex = 1
          Caption = 'Query'
          OnClick = SpeedButton_QueryClick
        end
        object Label102: TLabel
          Left = 9
          Top = 246
          Width = 20
          Height = 13
          Caption = 'Q'#65306
        end
        object Label103: TLabel
          Left = 89
          Top = 247
          Width = 49
          Height = 13
          Caption = 'Session'#65306
        end
        object Label91: TLabel
          Left = 19
          Top = 218
          Width = 100
          Height = 13
          Caption = 'Max inventory time'#65306
        end
        object ComboBox_IntervalTime: TComboBox
          Left = 217
          Top = 12
          Width = 56
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 0
          OnChange = ComboBox_IntervalTimeChange
        end
        object GroupBox31: TGroupBox
          Left = 7
          Top = 31
          Width = 266
          Height = 38
          Caption = 'TID query parameter'
          TabOrder = 1
          object Label52: TLabel
            Left = 8
            Top = 14
            Width = 50
            Height = 13
            Caption = 'Address'#65306
          end
          object Label65: TLabel
            Left = 128
            Top = 13
            Width = 45
            Height = 13
            Caption = 'Length'#65306
          end
          object Edit6: TEdit
            Left = 77
            Top = 11
            Width = 42
            Height = 21
            Enabled = False
            ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
            MaxLength = 2
            TabOrder = 0
            Text = '02'
            OnKeyPress = Edit2KeyPress
          end
          object Edit11: TEdit
            Left = 197
            Top = 10
            Width = 42
            Height = 21
            Enabled = False
            ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
            MaxLength = 2
            TabOrder = 1
            Text = '04'
            OnKeyPress = Edit2KeyPress
          end
        end
        object CheckBox_TID: TCheckBox
          Left = 9
          Top = 15
          Width = 74
          Height = 17
          Caption = 'TID'
          TabOrder = 2
          OnClick = CheckBox_TIDClick
        end
        object CheckBox19: TCheckBox
          Left = 79
          Top = 15
          Width = 66
          Height = 17
          Caption = 'Prompt'#10
          TabOrder = 3
        end
        object Com_Q: TComboBox
          Left = 36
          Top = 243
          Width = 47
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 4
        end
        object Com_S: TComboBox
          Left = 138
          Top = 243
          Width = 61
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 5
        end
        object GroupBox32: TGroupBox
          Left = 3
          Top = 69
          Width = 272
          Height = 117
          Caption = 'Mask Setting'
          TabOrder = 6
          object Label42: TLabel
            Left = 8
            Top = 16
            Width = 100
            Height = 13
            Caption = 'Start Address(Hex)'#65306
          end
          object Label43: TLabel
            Left = 16
            Top = 74
            Width = 70
            Height = 13
            Caption = 'Length(Hex)'#65306
          end
          object Label21: TLabel
            Left = 16
            Top = 97
            Width = 60
            Height = 13
            Caption = 'Data(Hex)'#65306
          end
          object CheckBox1: TCheckBox
            Left = 207
            Top = 9
            Width = 66
            Height = 17
            Caption = 'Enable'
            TabOrder = 0
          end
          object Edit2: TEdit
            Left = 114
            Top = 9
            Width = 61
            Height = 21
            ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
            MaxLength = 4
            TabOrder = 1
            Text = '0000'
            OnKeyPress = Edit2KeyPress
          end
          object Edit3: TEdit
            Left = 106
            Top = 66
            Width = 156
            Height = 21
            ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
            MaxLength = 2
            TabOrder = 2
            Text = '00'
            OnKeyPress = Edit2KeyPress
          end
          object GroupBox3: TGroupBox
            Left = 7
            Top = 28
            Width = 256
            Height = 35
            TabOrder = 3
            object R_EPC: TRadioButton
              Left = 7
              Top = 14
              Width = 57
              Height = 17
              Caption = 'EPC'
              TabOrder = 0
            end
            object R_TID: TRadioButton
              Left = 87
              Top = 14
              Width = 56
              Height = 17
              Caption = 'TID'
              TabOrder = 1
            end
            object R_User: TRadioButton
              Left = 156
              Top = 14
              Width = 65
              Height = 17
              Caption = 'User'
              TabOrder = 2
            end
          end
          object Edit1: TEdit
            Left = 104
            Top = 91
            Width = 161
            Height = 21
            ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
            TabOrder = 4
            Text = '00'
            OnKeyPress = Edit2KeyPress
          end
        end
        object Check_ant1: TCheckBox
          Left = 8
          Top = 189
          Width = 53
          Height = 17
          Caption = 'ANT1'
          Checked = True
          State = cbChecked
          TabOrder = 7
        end
        object Check_ant2: TCheckBox
          Left = 72
          Top = 189
          Width = 53
          Height = 17
          Caption = 'ANT2'
          TabOrder = 8
        end
        object Check_ant3: TCheckBox
          Left = 140
          Top = 189
          Width = 53
          Height = 17
          Caption = 'ANT3'
          TabOrder = 9
        end
        object Check_ant4: TCheckBox
          Left = 208
          Top = 189
          Width = 53
          Height = 17
          Caption = 'ANT4'
          TabOrder = 10
        end
        object ComboBox14: TComboBox
          Left = 114
          Top = 212
          Width = 145
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 11
        end
      end
      object GroupBox9: TGroupBox
        Left = 494
        Top = 398
        Width = 283
        Height = 73
        Caption = 'Kill Tag'
        TabOrder = 2
        object Label33: TLabel
          Left = 9
          Top = 40
          Width = 62
          Height = 26
          Caption = 'Kill Password'#13#10'(8 Hex):'
        end
        object Button_DestroyCard: TButton
          Left = 175
          Top = 44
          Width = 98
          Height = 23
          Action = Action_DestroyCard
          Caption = 'Kill Tag'
          TabOrder = 2
        end
        object Edit_DestroyCode: TEdit
          Left = 93
          Top = 44
          Width = 76
          Height = 21
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          MaxLength = 8
          TabOrder = 1
          Text = '00000000'
          OnKeyPress = Edit2KeyPress
        end
        object ComboBox_EPC3: TComboBox
          Tag = 3
          Left = 10
          Top = 15
          Width = 263
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 0
        end
      end
      object GroupBox23: TGroupBox
        Left = 497
        Top = 471
        Width = 280
        Height = 75
        Caption = 'Write EPC(Random write one tag in the antenna)'
        TabOrder = 3
        object Label38: TLabel
          Left = 4
          Top = 44
          Width = 87
          Height = 26
          Caption = 'Access Password '#13#10'(8 Hex):'
        end
        object Label39: TLabel
          Left = 8
          Top = 16
          Width = 53
          Height = 26
          Caption = 'Write EPC:'#13#10'(1-15Word)'
        end
        object Edit_AccessCode3: TEdit
          Left = 93
          Top = 47
          Width = 76
          Height = 21
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          MaxLength = 8
          TabOrder = 2
          Text = '00000000'
          OnKeyPress = Edit2KeyPress
        end
        object Button_WriteEPC_G2: TButton
          Left = 176
          Top = 45
          Width = 94
          Height = 25
          Action = Action_WriteEPC_G2
          Caption = 'Write EPC'
          TabOrder = 1
        end
        object Edit_WriteEPC: TEdit
          Left = 66
          Top = 17
          Width = 169
          Height = 21
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          MaxLength = 60
          TabOrder = 0
          Text = '0000'
          OnKeyPress = Edit2KeyPress
        end
      end
      object GroupBox20: TGroupBox
        Left = 497
        Top = 279
        Width = 281
        Height = 120
        Caption = 'Read Protection'
        TabOrder = 4
        object Label32: TLabel
          Left = 9
          Top = 41
          Width = 121
          Height = 13
          Caption = 'Access Password(8 Hex):'
        end
        object ComboBox_EPC4: TComboBox
          Tag = 3
          Left = 10
          Top = 15
          Width = 261
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 0
        end
        object Edit_AccessCode4: TEdit
          Left = 154
          Top = 41
          Width = 113
          Height = 21
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          MaxLength = 8
          TabOrder = 2
          Text = '00000000'
          OnKeyPress = Edit2KeyPress
        end
        object Button_SetReadProtect_G2: TButton
          Left = 9
          Top = 61
          Width = 128
          Height = 25
          Action = Action_SetReadProtect_G2
          Caption = 'Set Privacy By EPC'
          TabOrder = 1
        end
        object Button_SetMultiReadProtect_G2: TButton
          Left = 144
          Top = 61
          Width = 129
          Height = 25
          Action = Action_SetMultiReadProtect_G2
          Caption = 'Set Privacy Without EPC'
          TabOrder = 3
        end
        object Button_RemoveReadProtect_G2: TButton
          Left = 9
          Top = 89
          Width = 127
          Height = 25
          Action = Action_RemoveReadProtect_G2
          Caption = 'Reset Privacy'
          TabOrder = 4
        end
        object Button_CheckReadProtected_G2: TButton
          Left = 144
          Top = 89
          Width = 129
          Height = 25
          Action = Action_CheckReadProtected_G2
          Caption = 'Check Privacy'
          TabOrder = 5
        end
      end
      object GroupBox21: TGroupBox
        Left = 495
        Top = 547
        Width = 281
        Height = 110
        Caption = 'EAS Alarm'
        TabOrder = 5
        object Label35: TLabel
          Left = 9
          Top = 37
          Width = 84
          Height = 26
          Caption = 'Access Password'#13#10'(8 Hex):'
        end
        object SpeedButton_CheckAlarm_G2: TSpeedButton
          Left = 192
          Top = 75
          Width = 81
          Height = 25
          AllowAllUp = True
          GroupIndex = 3
          Caption = 'EAS Alarm'
          OnClick = SpeedButton_CheckAlarm_G2Click
        end
        object Label_Alarm: TLabel
          Left = 216
          Top = 37
          Width = 30
          Height = 30
          Caption = #9679
          Color = clBtnFace
          Font.Charset = GB2312_CHARSET
          Font.Color = clRed
          Font.Height = -30
          Font.Name = 'MS Sans Serif'
          Font.Style = []
          ParentColor = False
          ParentFont = False
          Visible = False
        end
        object Button_SetEASAlarm_G2: TButton
          Left = 96
          Top = 75
          Width = 81
          Height = 25
          Caption = 'EAS Configure'
          TabOrder = 3
          OnClick = Action_SetEASAlarm_G2Execute
        end
        object ComboBox_EPC5: TComboBox
          Tag = 3
          Left = 10
          Top = 14
          Width = 264
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 0
        end
        object Edit_AccessCode5: TEdit
          Left = 104
          Top = 40
          Width = 62
          Height = 21
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          MaxLength = 8
          TabOrder = 1
          Text = '00000000'
          OnKeyPress = Edit2KeyPress
        end
        object GroupBox24: TGroupBox
          Left = 10
          Top = 62
          Width = 79
          Height = 43
          TabOrder = 2
          object Alarm_G2: TRadioButton
            Left = 9
            Top = 8
            Width = 57
            Height = 17
            Caption = 'Alarm'
            TabOrder = 0
          end
          object NoAlarm_G2: TRadioButton
            Left = 9
            Top = 24
            Width = 65
            Height = 17
            Caption = 'No Alarm'
            TabOrder = 1
          end
        end
      end
      object GroupBox5: TGroupBox
        Left = 8
        Top = 483
        Width = 481
        Height = 168
        Caption = 'Set Protect For Reading Or Writing'
        TabOrder = 6
        object Label24: TLabel
          Left = 224
          Top = 127
          Width = 124
          Height = 13
          Caption = 'Access Password (8 Hex):'
        end
        object ComboBox_EPC1: TComboBox
          Tag = 1
          Left = 8
          Top = 18
          Width = 209
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 1
        end
        object Button_SetProtectState: TButton
          Left = 368
          Top = 135
          Width = 97
          Height = 25
          Action = Action_SetProtectState
          Caption = 'Lock'
          TabOrder = 4
        end
        object Edit_AccessCode1: TEdit
          Left = 224
          Top = 142
          Width = 89
          Height = 21
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          MaxLength = 8
          TabOrder = 5
          Text = '00000000'
          OnKeyPress = Edit2KeyPress
        end
        object GroupBox1: TGroupBox
          Left = 224
          Top = 7
          Width = 250
          Height = 31
          TabOrder = 0
          object P_Reserve: TRadioButton
            Left = 8
            Top = 8
            Width = 71
            Height = 17
            Caption = 'Password'
            TabOrder = 0
          end
          object P_EPC: TRadioButton
            Left = 84
            Top = 8
            Width = 46
            Height = 17
            Caption = 'EPC'
            TabOrder = 1
          end
          object P_TID: TRadioButton
            Left = 140
            Top = 8
            Width = 43
            Height = 17
            Caption = 'TID'
            TabOrder = 2
          end
          object P_User: TRadioButton
            Left = 192
            Top = 8
            Width = 49
            Height = 17
            Caption = 'User'
            TabOrder = 3
          end
        end
        object GroupBox16: TGroupBox
          Left = 8
          Top = 44
          Width = 212
          Height = 116
          Caption = 'Lock of Password'
          TabOrder = 2
          object GroupBox4: TGroupBox
            Left = 8
            Top = 12
            Width = 198
            Height = 31
            TabOrder = 0
            object DestroyCode: TRadioButton
              Left = 3
              Top = 9
              Width = 85
              Height = 17
              Caption = 'Kill Password'
              TabOrder = 0
            end
            object AccessCode: TRadioButton
              Left = 88
              Top = 9
              Width = 106
              Height = 17
              Caption = 'Access Password'
              TabOrder = 1
            end
          end
          object NoProect: TRadioButton
            Left = 3
            Top = 46
            Width = 208
            Height = 17
            Caption = 'Readable and  writeable from any state'
            TabOrder = 1
          end
          object Always: TRadioButton
            Left = 3
            Top = 81
            Width = 205
            Height = 17
            Caption = 'Permanently readable and writeable'
            TabOrder = 3
          end
          object Proect: TRadioButton
            Left = 3
            Top = 63
            Width = 211
            Height = 17
            Caption = 'Readable and writeable from the secured state'
            TabOrder = 2
          end
          object AlwaysNot: TRadioButton
            Left = 3
            Top = 97
            Width = 169
            Height = 17
            Caption = 'Never readable and writeable'
            TabOrder = 4
          end
        end
        object GroupBox18: TGroupBox
          Left = 224
          Top = 40
          Width = 249
          Height = 86
          Caption = 'Lock of EPC TID and User Bank'
          TabOrder = 3
          object NoProect2: TRadioButton
            Left = 8
            Top = 14
            Width = 185
            Height = 17
            Caption = 'Writeable from any state'
            TabOrder = 0
          end
          object AlwaysNot2: TRadioButton
            Left = 8
            Top = 64
            Width = 113
            Height = 17
            Caption = 'Never writeable'
            TabOrder = 3
          end
          object Proect2: TRadioButton
            Left = 8
            Top = 30
            Width = 201
            Height = 17
            Caption = 'Writeable from the secured state'
            TabOrder = 1
          end
          object Always2: TRadioButton
            Left = 8
            Top = 47
            Width = 185
            Height = 17
            Caption = 'Permanently writeable'
            TabOrder = 2
          end
        end
      end
      object GroupBox10: TGroupBox
        Left = 8
        Top = 274
        Width = 481
        Height = 208
        Caption = 'Read Data / Write Data / Block Erase'
        TabOrder = 7
        object Label9: TLabel
          Left = 8
          Top = 129
          Width = 140
          Height = 13
          Caption = 'Password(Read/Block Erase)'
        end
        object Label18: TLabel
          Left = 8
          Top = 155
          Width = 82
          Height = 13
          Caption = 'Write Data (Hex):'
        end
        object Label19: TLabel
          Left = 8
          Top = 75
          Width = 157
          Height = 13
          Caption = 'Address of Tag Data(Word/Hex):'
        end
        object Label20: TLabel
          Left = 5
          Top = 101
          Width = 165
          Height = 13
          Caption = 'Length of Data(Read/Block Erase:'
        end
        object SpeedButton_Read_G2: TSpeedButton
          Left = 6
          Top = 177
          Width = 44
          Height = 25
          AllowAllUp = True
          GroupIndex = 5
          Caption = 'Read'
          OnClick = SpeedButton_Read_G2Click
        end
        object ComboBox_EPC2: TComboBox
          Tag = 2
          Left = 8
          Top = 16
          Width = 266
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 1
        end
        object Edit_AccessCode2: TEdit
          Left = 152
          Top = 125
          Width = 121
          Height = 21
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          MaxLength = 8
          TabOrder = 5
          Text = '00000000'
          OnKeyPress = Edit2KeyPress
        end
        object Edit_WriteData: TEdit
          Left = 112
          Top = 151
          Width = 161
          Height = 21
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          TabOrder = 6
          Text = '0000'
          OnChange = Edit_WriteDataChange
          OnKeyPress = Edit_WriteDataKeyPress
        end
        object Edit_WordPtr: TEdit
          Left = 191
          Top = 73
          Width = 78
          Height = 21
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          MaxLength = 4
          TabOrder = 3
          Text = '0000'
          OnKeyPress = Edit2KeyPress
        end
        object Edit_Len: TEdit
          Left = 191
          Top = 99
          Width = 75
          Height = 21
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          MaxLength = 3
          TabOrder = 4
          Text = '4'
          OnKeyPress = Edit8KeyPress
        end
        object Memo_DataShow: TMemo
          Left = 279
          Top = 40
          Width = 194
          Height = 133
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ScrollBars = ssVertical
          TabOrder = 0
        end
        object GroupBox6: TGroupBox
          Left = 8
          Top = 36
          Width = 265
          Height = 33
          TabOrder = 2
          object C_Reserve: TRadioButton
            Left = 2
            Top = 10
            Width = 65
            Height = 17
            Caption = 'Password'
            TabOrder = 0
            OnClick = C_ReserveClick
          end
          object C_EPC: TRadioButton
            Left = 67
            Top = 10
            Width = 57
            Height = 17
            Caption = 'EPC'
            TabOrder = 1
            OnClick = C_EPCClick
          end
          object C_TID: TRadioButton
            Left = 131
            Top = 10
            Width = 56
            Height = 17
            Caption = 'TID'
            TabOrder = 2
            OnClick = C_TIDClick
          end
          object C_User: TRadioButton
            Left = 192
            Top = 10
            Width = 65
            Height = 17
            Caption = 'User'
            TabOrder = 3
            OnClick = C_UserClick
          end
        end
        object Button16: TButton
          Left = 251
          Top = 178
          Width = 65
          Height = 25
          Caption = 'Clear'
          TabOrder = 9
          OnClick = Button16Click
        end
        object Button_DataWrite: TButton
          Left = 56
          Top = 177
          Width = 42
          Height = 25
          Action = Action_ShowOrChangeData_write
          Caption = 'Write'
          TabOrder = 7
        end
        object Button_BlockErase: TButton
          Left = 175
          Top = 177
          Width = 70
          Height = 25
          Action = Action_ShowOrChangeData_BlockErase
          Caption = 'Block Erase'
          TabOrder = 8
        end
        object Button_BlockWrite: TButton
          Left = 105
          Top = 177
          Width = 63
          Height = 25
          Action = Action_ShowOrChangeData_BlockWrite
          Caption = 'BlockWrite'
          TabOrder = 10
        end
        object CheckBox18: TCheckBox
          Left = 292
          Top = 16
          Width = 128
          Height = 17
          Caption = 'Compute and add PC: '
          TabOrder = 11
          OnClick = CheckBox18Click
        end
        object Edit_PC: TEdit
          Left = 420
          Top = 12
          Width = 53
          Height = 21
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          TabOrder = 12
          Text = '0800'
        end
        object Button43: TButton
          Left = 321
          Top = 178
          Width = 75
          Height = 25
          Caption = 'Ext Read'
          TabOrder = 13
          OnClick = Button43Click
        end
        object Button44: TButton
          Left = 400
          Top = 178
          Width = 75
          Height = 25
          Caption = 'Ext Write'
          TabOrder = 14
          OnClick = Button44Click
        end
      end
    end
    object TabSheet2: TTabSheet
      Caption = 'Mix Test'
      ImageIndex = 9
      object GroupBox60: TGroupBox
        Left = 8
        Top = -12
        Width = 480
        Height = 665
        Caption = #21345#29255#26174#31034
        TabOrder = 0
        object Label107: TLabel
          Left = 297
          Top = 630
          Width = 49
          Height = 13
          Caption = 'Number'#65306
        end
        object ListView4: TListView
          Left = 8
          Top = 13
          Width = 465
          Height = 596
          Columns = <
            item
              Caption = 'No.'
            end
            item
              Caption = 'EPC'
              Width = 160
            end
            item
              Caption = 'Data'
              Width = 150
            end
            item
              Caption = 'Times'
            end
            item
              Caption = 'RSSI'
            end>
          GridLines = True
          TabOrder = 0
          ViewStyle = vsReport
        end
        object Edit_num: TEdit
          Left = 362
          Top = 615
          Width = 102
          Height = 45
          Font.Charset = DEFAULT_CHARSET
          Font.Color = clBlue
          Font.Height = -32
          Font.Name = 'MS Sans Serif'
          Font.Style = []
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ParentFont = False
          TabOrder = 1
        end
      end
      object GroupBox61: TGroupBox
        Left = 492
        Top = 0
        Width = 285
        Height = 337
        Caption = 'Query'
        TabOrder = 1
        object SpeedButton3: TSpeedButton
          Left = 207
          Top = 296
          Width = 68
          Height = 33
          AllowAllUp = True
          GroupIndex = 1
          Caption = 'Inventory'
          OnClick = SpeedButton3Click
        end
        object Label109: TLabel
          Left = 21
          Top = 199
          Width = 20
          Height = 13
          Caption = 'Q'#65306
        end
        object Label110: TLabel
          Left = 137
          Top = 200
          Width = 49
          Height = 13
          Caption = 'Session'#65306
        end
        object Label111: TLabel
          Left = 19
          Top = 172
          Width = 80
          Height = 13
          Caption = 'Max scan time'#65306
        end
        object cbb_Q: TComboBox
          Left = 44
          Top = 196
          Width = 77
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 0
          Items.Strings = (
            '0'
            '1'
            '2'
            '3'
            '4'
            '5'
            '6'
            '7'
            '8'
            '9'
            '10'
            '11'
            '12'
            '13'
            '14'
            '15')
        end
        object cbb_S: TComboBox
          Left = 195
          Top = 196
          Width = 75
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 1
          Items.Strings = (
            'S0'
            'S1'
            'S2'
            'S3')
        end
        object GroupBox62: TGroupBox
          Left = 3
          Top = 13
          Width = 272
          Height = 128
          Caption = 'Mask'
          TabOrder = 2
          object Label114: TLabel
            Left = 8
            Top = 16
            Width = 126
            Height = 13
            Caption = 'Mask start address(Hex)'#65306
          end
          object Label115: TLabel
            Left = 16
            Top = 73
            Width = 109
            Height = 13
            Caption = 'Mask bit length(Hex)'#65306
          end
          object Label116: TLabel
            Left = 16
            Top = 96
            Width = 87
            Height = 13
            Caption = 'Mask data(Hex)'#65306
          end
          object CheckBox2: TCheckBox
            Left = 207
            Top = 9
            Width = 66
            Height = 17
            Caption = 'Enable'
            TabOrder = 0
          end
          object Edit_maskaddr: TEdit
            Left = 139
            Top = 9
            Width = 61
            Height = 21
            ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
            MaxLength = 4
            TabOrder = 1
            Text = '0000'
            OnKeyPress = Edit2KeyPress
          end
          object edt_masklen: TEdit
            Left = 116
            Top = 65
            Width = 149
            Height = 21
            ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
            MaxLength = 2
            TabOrder = 2
            Text = '00'
            OnKeyPress = Edit2KeyPress
          end
          object GroupBox63: TGroupBox
            Left = 7
            Top = 28
            Width = 256
            Height = 35
            TabOrder = 3
            object rb_mepc: TRadioButton
              Left = 7
              Top = 14
              Width = 57
              Height = 17
              Caption = 'EPC'
              TabOrder = 0
            end
            object rb_mtid: TRadioButton
              Left = 87
              Top = 14
              Width = 56
              Height = 17
              Caption = 'TID'
              TabOrder = 1
            end
            object rb_muser: TRadioButton
              Left = 156
              Top = 14
              Width = 65
              Height = 17
              Caption = 'User'
              TabOrder = 2
            end
          end
          object edt_maskdata: TEdit
            Left = 104
            Top = 90
            Width = 161
            Height = 21
            ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
            TabOrder = 4
            Text = '00'
            OnKeyPress = Edit2KeyPress
          end
        end
        object chk_ant1: TCheckBox
          Left = 8
          Top = 145
          Width = 53
          Height = 17
          Caption = 'ANT1'
          Checked = True
          State = cbChecked
          TabOrder = 3
        end
        object chk_ant2: TCheckBox
          Left = 72
          Top = 145
          Width = 53
          Height = 17
          Caption = 'ANT2'
          TabOrder = 4
        end
        object chk_ant3: TCheckBox
          Left = 140
          Top = 145
          Width = 53
          Height = 17
          Caption = 'ANT3'
          TabOrder = 5
        end
        object chk_ant4: TCheckBox
          Left = 208
          Top = 145
          Width = 53
          Height = 17
          Caption = 'ANT4'
          TabOrder = 6
        end
        object cbb_maxtime: TComboBox
          Left = 114
          Top = 166
          Width = 157
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 7
        end
        object TGroupBox
          Left = 6
          Top = 216
          Width = 272
          Height = 75
          TabOrder = 8
          object Label37: TLabel
            Left = 16
            Top = 16
            Width = 54
            Height = 13
            Caption = 'Read mem:'
          end
          object Label108: TLabel
            Left = 159
            Top = 16
            Width = 41
            Height = 13
            Caption = 'Address:'
          end
          object Label112: TLabel
            Left = 163
            Top = 45
            Width = 36
            Height = 13
            Caption = 'Length:'
          end
          object Label113: TLabel
            Left = 5
            Top = 45
            Width = 49
            Height = 13
            Caption = 'Password:'
          end
          object cbb_readmem: TComboBox
            Left = 80
            Top = 13
            Width = 77
            Height = 21
            ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
            ItemHeight = 13
            TabOrder = 0
            Items.Strings = (
              'Password'
              'EPC'
              'TID'
              'User')
          end
          object edt_readaddr: TEdit
            Left = 200
            Top = 12
            Width = 59
            Height = 21
            ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
            MaxLength = 4
            TabOrder = 1
            Text = '0002'
            OnKeyPress = Edit_WriteDataKeyPress
          end
          object edt_readlen: TEdit
            Left = 200
            Top = 41
            Width = 59
            Height = 21
            ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
            MaxLength = 2
            TabOrder = 2
            Text = '4'
            OnKeyPress = Edit_WriteDataKeyPress
          end
          object edt_readpsd: TEdit
            Left = 56
            Top = 41
            Width = 97
            Height = 21
            ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
            MaxLength = 8
            TabOrder = 3
            Text = '00000000'
            OnKeyPress = Edit_WriteDataKeyPress
          end
        end
      end
    end
    object TabSheet_6B: TTabSheet
      Caption = '18000-6B Test'
      ImageIndex = 6
      object GroupBox13: TGroupBox
        Left = 5
        Top = 4
        Width = 769
        Height = 309
        Caption = 'List ID of Tags'
        TabOrder = 0
        object ListView_ID_6B: TListView
          Left = 8
          Top = 16
          Width = 750
          Height = 282
          Columns = <
            item
              Caption = 'No.'
            end
            item
              Caption = 'ID'
              Width = 450
            end
            item
              Caption = 'ANT(4,3,2,1)'
              Width = 100
            end
            item
              Caption = 'Times'
            end
            item
              Caption = 'RSSI'
            end>
          GridLines = True
          TabOrder = 0
          ViewStyle = vsReport
        end
      end
      object GroupBox19: TGroupBox
        Left = 5
        Top = 316
        Width = 321
        Height = 132
        Caption = 'Query Tag'
        TabOrder = 1
        object Label30: TLabel
          Left = 8
          Top = 30
          Width = 67
          Height = 13
          Caption = 'Read Interval:'
        end
        object SpeedButton_Query_6B: TSpeedButton
          Left = 221
          Top = 79
          Width = 89
          Height = 26
          AllowAllUp = True
          GroupIndex = 1
          Caption = 'Query by one'
          OnClick = Action_Query_6BExecute
        end
        object ComboBox_IntervalTime_6B: TComboBox
          Left = 104
          Top = 25
          Width = 207
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 0
          OnChange = ComboBox_IntervalTime_6BChange
        end
        object Byone_6B: TRadioButton
          Left = 8
          Top = 70
          Width = 121
          Height = 17
          Caption = 'Query by one'
          TabOrder = 1
        end
        object Bycondition_6B: TRadioButton
          Left = 8
          Top = 98
          Width = 145
          Height = 17
          Caption = 'Query by Condition'
          TabOrder = 2
        end
      end
      object GroupBox14: TGroupBox
        Left = 5
        Top = 452
        Width = 321
        Height = 168
        Caption = 'Query Tags by Condition'
        TabOrder = 2
        object Label34: TLabel
          Left = 8
          Top = 132
          Width = 133
          Height = 13
          Caption = 'Condition(<=8 Hex Number):'
        end
        object Label31: TLabel
          Left = 8
          Top = 92
          Width = 134
          Height = 13
          Caption = 'Address of Tag Data(0-223):'
        end
        object Edit_Query_StartAddress_6B: TEdit
          Left = 160
          Top = 87
          Width = 97
          Height = 21
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          MaxLength = 3
          TabOrder = 4
          Text = '0'
          OnKeyPress = Edit8KeyPress
        end
        object Edit_ConditionContent_6B: TEdit
          Left = 160
          Top = 124
          Width = 97
          Height = 21
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          MaxLength = 16
          TabOrder = 5
          Text = '00'
          OnKeyPress = Edit2KeyPress
        end
        object Less_6B: TRadioButton
          Left = 8
          Top = 56
          Width = 129
          Height = 17
          Caption = 'Less than Condition'
          TabOrder = 2
        end
        object Different_6B: TRadioButton
          Left = 160
          Top = 24
          Width = 113
          Height = 17
          Caption = 'Unequal Condition'
          Checked = True
          TabOrder = 1
          TabStop = True
        end
        object Same_6B: TRadioButton
          Left = 8
          Top = 24
          Width = 113
          Height = 17
          Caption = 'Equal Condition'
          TabOrder = 0
        end
        object Greater_6B: TRadioButton
          Left = 160
          Top = 56
          Width = 145
          Height = 17
          Caption = 'Greater than Condition'
          TabOrder = 3
        end
      end
      object GroupBox15: TGroupBox
        Left = 333
        Top = 316
        Width = 441
        Height = 304
        Caption = 
          'Read and Write Data Block / Permanently Write  Protect Block of ' +
          ' byte'
        TabOrder = 3
        object Label40: TLabel
          Left = 9
          Top = 90
          Width = 165
          Height = 13
          Caption = 'Write Data (1-32 Byte/Hex):           '
        end
        object Label41: TLabel
          Left = 9
          Top = 49
          Width = 102
          Height = 26
          Caption = 'Start/Protect Address'#13#10'(00-E9)(Hex):   '
        end
        object Label44: TLabel
          Left = 218
          Top = 49
          Width = 75
          Height = 26
          Caption = 'Length of Data:'#13#10'(1-32/Byte/D)   '
        end
        object SpeedButton_Read_6B: TSpeedButton
          Left = 8
          Top = 117
          Width = 49
          Height = 25
          AllowAllUp = True
          GroupIndex = 5
          Caption = 'Read'
          OnClick = SpeedButton_Read_6BClick
        end
        object SpeedButton_Write_6B: TSpeedButton
          Left = 73
          Top = 117
          Width = 49
          Height = 25
          AllowAllUp = True
          GroupIndex = 5
          Caption = 'Write'
          OnClick = SpeedButton_Read_6BClick
        end
        object ComboBox_ID1_6B: TComboBox
          Tag = 2
          Left = 9
          Top = 20
          Width = 422
          Height = 21
          Style = csDropDownList
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ItemHeight = 13
          TabOrder = 0
        end
        object Edit_WriteData_6B: TEdit
          Left = 150
          Top = 85
          Width = 277
          Height = 21
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          TabOrder = 3
          Text = '0000'
          OnKeyPress = Edit2KeyPress
        end
        object Edit_StartAddress_6B: TEdit
          Left = 121
          Top = 54
          Width = 66
          Height = 21
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          MaxLength = 2
          TabOrder = 1
          Text = '00'
          OnKeyPress = Edit2KeyPress
        end
        object Edit_Len_6B: TEdit
          Left = 320
          Top = 54
          Width = 109
          Height = 21
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          MaxLength = 2
          TabOrder = 2
          Text = '12'
          OnKeyPress = Edit8KeyPress
        end
        object Memo_DataShow_6B: TMemo
          Left = 8
          Top = 152
          Width = 420
          Height = 143
          ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
          ScrollBars = ssVertical
          TabOrder = 7
        end
        object Button10: TButton
          Left = 140
          Top = 117
          Width = 74
          Height = 25
          Action = Action_LockByte_6B
          Caption = 'Lock'
          TabOrder = 4
        end
        object Button11: TButton
          Left = 230
          Top = 117
          Width = 125
          Height = 25
          Action = Action_CheckLock_6B
          Caption = 'Check Lock'
          TabOrder = 5
        end
        object Button12: TButton
          Left = 368
          Top = 117
          Width = 60
          Height = 25
          Caption = 'Clear'
          TabOrder = 6
          OnClick = Button12Click
        end
      end
    end
    object TabSheet3: TTabSheet
      Caption = 'Frequency Analysis'
      ImageIndex = 4
      object Label62: TLabel
        Left = 42
        Top = 11
        Width = 79
        Height = 13
        AutoSize = False
        Caption = 'Frequency'
      end
      object Label63: TLabel
        Left = 214
        Top = 11
        Width = 121
        Height = 13
        AutoSize = False
        Caption = 'Times'
      end
      object Label64: TLabel
        Left = 398
        Top = 11
        Width = 55
        Height = 13
        Caption = 'Percentage'
      end
      object ListBox1: TListBox
        Left = 12
        Top = 27
        Width = 761
        Height = 561
        BiDiMode = bdLeftToRight
        Color = clBtnHighlight
        Ctl3D = False
        ExtendedSelect = False
        Font.Charset = ANSI_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'Courier'
        Font.Style = []
        ImeName = #20013#25991' - QQ'#25340#38899#36755#20837#27861
        ItemHeight = 13
        ParentBiDiMode = False
        ParentCtl3D = False
        ParentFont = False
        ParentShowHint = False
        ShowHint = False
        TabOrder = 0
      end
      object Button21: TButton
        Left = 509
        Top = 594
        Width = 75
        Height = 25
        Caption = 'Start'
        Enabled = False
        TabOrder = 1
        OnClick = Button21Click
      end
      object Button23: TButton
        Left = 600
        Top = 594
        Width = 75
        Height = 25
        Caption = 'Stop'
        Enabled = False
        TabOrder = 2
        OnClick = Button23Click
      end
      object Button24: TButton
        Left = 688
        Top = 594
        Width = 75
        Height = 25
        Caption = 'Clear'
        TabOrder = 3
        OnClick = Button24Click
      end
    end
    object TabSheet4: TTabSheet
      Caption = 'TCPIP net comfig'
      ImageIndex = 5
      object GroupBox42: TGroupBox
        Left = 2
        Top = 30
        Width = 767
        Height = 591
        Caption = 'Device list'
        TabOrder = 0
        object ListView2: TListView
          Left = 8
          Top = 15
          Width = 753
          Height = 569
          Columns = <
            item
              Caption = 'Device name'
              Width = 210
            end
            item
              Caption = 'Device IP'
              Width = 210
            end
            item
              Caption = 'Device Mac'
              Width = 210
            end>
          GridLines = True
          RowSelect = True
          TabOrder = 0
          ViewStyle = vsReport
          OnDblClick = ListView2DblClick
        end
      end
      object ToolBar1: TToolBar
        Left = 0
        Top = 0
        Width = 778
        Height = 29
        ButtonHeight = 0
        ButtonWidth = 0
        Caption = 'ToolBar1'
        Flat = True
        Menu = MainMenu1
        ShowCaptions = True
        TabOrder = 1
      end
    end
  end
  object StatusBar1: TStatusBar
    Left = 0
    Top = 685
    Width = 792
    Height = 19
    AutoHint = True
    Panels = <
      item
        Width = 600
      end
      item
        Text = 'COM'
        Width = 56
      end
      item
        Width = 200
      end>
  end
  object Timer_Test_: TTimer
    Enabled = False
    Interval = 50
    OnTimer = Timer_Test_Timer
    Left = 752
    Top = 218
  end
  object Timer_G2_Read: TTimer
    Enabled = False
    Interval = 200
    OnTimer = Timer_G2_ReadTimer
    Left = 755
    Top = 58
  end
  object Timer_G2_Alarm: TTimer
    Interval = 200
    OnTimer = Timer_G2_AlarmTimer
    Left = 752
    Top = 186
  end
  object Timer1: TTimer
    Enabled = False
    Interval = 50
    Left = 754
    Top = 18
  end
  object Timer_Test_6B: TTimer
    Enabled = False
    Interval = 50
    OnTimer = Timer_Test_6BTimer
    Left = 755
    Top = 154
  end
  object Timer_6B_ReadWrite: TTimer
    Enabled = False
    Interval = 200
    OnTimer = Timer_6B_ReadWriteTimer
    Left = 754
    Top = 122
  end
  object MainMenu1: TMainMenu
    Left = 412
    Top = 24
    object Operation1: TMenuItem
      Caption = 'Opetion'
      object Search1: TMenuItem
        Caption = 'Search'
        OnClick = Search1Click
      end
      object clear1: TMenuItem
        Caption = 'Clear'
        OnClick = clear1Click
      end
      object xxit1: TMenuItem
        Caption = 'Exit'
        OnClick = xxit1Click
      end
    end
    object tools1: TMenuItem
      Caption = 'Tool'
      object IE1: TMenuItem
        Caption = 'IE'
        OnClick = IE1Click
      end
      object elnet1: TMenuItem
        Caption = 'Telnet'
        OnClick = elnet1Click
      end
      object Ping1: TMenuItem
        Caption = 'Ping'
        OnClick = Ping1Click
      end
    end
    object Language1: TMenuItem
      Caption = 'Language'
      object English1: TMenuItem
        Caption = 'English'
      end
    end
    object Help1: TMenuItem
      Caption = 'Help'
      object About1: TMenuItem
        Caption = 'About'
      end
    end
  end
  object Timer2: TTimer
    Enabled = False
    Interval = 50
    OnTimer = Timer2Timer
    Left = 756
    Top = 248
  end
  object ActionList1: TActionList
    Left = 755
    Top = 90
    object Action_GetReaderInformation: TAction
      Tag = 1
      Category = #20018#21475#25171#24320#21363#21487#25191#34892'(TAG=1)'
      Caption = 'Get Reader Information'
      OnExecute = Action_GetReaderInformationExecute
      OnUpdate = Action_GetReaderInformationUpdate
    end
    object Action_OpenCOM: TAction
      Category = #36890#35759
      Caption = #25171#24320#31471#21475
    end
    object Action_OpenRf: TAction
      Tag = 1
      Category = #20018#21475#25171#24320#21363#21487#25191#34892'(TAG=1)'
      Caption = #25171#24320#23556#39057
    end
    object Action_CloseCOM: TAction
      Category = #36890#35759
      Caption = #20851#38381#31471#21475
    end
    object Action_CloseRf: TAction
      Tag = 1
      Category = #20018#21475#25171#24320#21363#21487#25191#34892'(TAG=1)'
      Caption = #20851#38381#23556#39057
    end
    object Action_WriteComAdr: TAction
      Tag = 1
      Category = #20018#21475#25171#24320#21363#21487#25191#34892'(TAG=1)'
      Caption = #20889#20837#35835#20889#22120#22320#22336
    end
    object Action_WriteInventoryScanTime: TAction
      Tag = 1
      Category = #20018#21475#25171#24320#21363#21487#25191#34892'(TAG=1)'
      Caption = #20889#20837
      Hint = #20889#20837#35810#26597#21629#20196#26368#22823#21709#24212#26102#38388
    end
    object Action_OpenTestMode: TAction
      Category = #27979#35797#27169#24335
      Caption = #26597#35810#26631#31614
    end
    object Action_CloseTestMode: TAction
      Category = #27979#35797#27169#24335
      Caption = #20851#38381#27979#35797#27169#24335
    end
    object Action_GetSystemInformation: TAction
      Tag = 2
      Category = #21345#29255#25805#20316'(TAG=2)'
      Caption = #33719#21462#30005#23376#26631#31614#35814#32454#20449#24687
    end
    object Action_SetReaderInformation: TAction
      Category = #20018#21475#25171#24320#21363#21487#25191#34892'(TAG=1)'
      Caption = #35774#32622#21442#25968
      OnExecute = Action_SetReaderInformationExecute
    end
    object Action_SetReaderInformation_0: TAction
      Category = #20018#21475#25171#24320#21363#21487#25191#34892'(TAG=1)'
      Caption = #24674#22797#20986#21378#21442#25968
      OnExecute = Action_SetReaderInformationExecute
    end
    object Action_Inventory: TAction
      Category = #20018#21475#25171#24320#21363#21487#25191#34892'(TAG=1)'
      Caption = 'Action_Inventory'
      OnExecute = Action_InventoryExecute
    end
    object Action_ShowOrChangeData: TAction
      Category = #21345#29255#25805#20316'(TAG=2)'
      Caption = #35835
    end
    object Action_SetProtectState: TAction
      Category = #21345#29255#25805#20316'(TAG=2)'
      Caption = #35774#32622#20445#25252
      OnExecute = Action_SetProtectStateExecute
      OnUpdate = Action_SetProtectStateUpdate
    end
    object Action_DestroyCard: TAction
      Category = #21345#29255#25805#20316'(TAG=2)'
      Caption = #38144#27585
      OnExecute = Action_DestroyCardExecute
    end
    object Action_SelfTestMode: TAction
      Category = #27979#35797#27169#24335
      Caption = #36827#20837
      OnExecute = Action_SelfTestModeExecute
    end
    object Action_SelfTestMode2: TAction
      Category = #27979#35797#27169#24335
      Caption = #36864#20986
      OnExecute = Action_SelfTestModeExecute
    end
    object Action_RfOutput: TAction
      Category = #20018#21475#25171#24320#21363#21487#25191#34892'(TAG=1)'
      Caption = #25171#24320
      OnExecute = Action_RfOutputExecute
    end
    object Action_RfOutput2: TAction
      Category = #20018#21475#25171#24320#21363#21487#25191#34892'(TAG=1)'
      Caption = #20851#38381
      OnExecute = Action_RfOutputExecute
    end
    object Action_SetDAC: TAction
      Category = #20018#21475#25171#24320#21363#21487#25191#34892'(TAG=1)'
      Caption = #35843#25972'PWM'#20540
    end
    object Action_GetDAC: TAction
      Category = #20018#21475#25171#24320#21363#21487#25191#34892'(TAG=1)'
      Caption = #35835#21462'PWM'#37197#32622
    end
    object Action_SetPowerParameter: TAction
      Category = #20018#21475#25171#24320#21363#21487#25191#34892'(TAG=1)'
      Caption = #35774#23450#21151#29575#21442#25968
    end
    object Action_SolidifyPower: TAction
      Category = #20018#21475#25171#24320#21363#21487#25191#34892'(TAG=1)'
      Caption = #22266#21270#21151#29575#37197#32622
    end
    object Action_CheckPowerParameter: TAction
      Category = #20018#21475#25171#24320#21363#21487#25191#34892'(TAG=1)'
      Caption = #26816#27979#21151#29575#21442#25968#37197#32622
    end
    object Action_GetStartInformation: TAction
      Category = #20018#21475#25171#24320#21363#21487#25191#34892'(TAG=1)'
      Caption = #35835#21462#21551#21160#20449#24687
    end
    object Action_ReadPowerParameter: TAction
      Category = #20018#21475#25171#24320#21363#21487#25191#34892'(TAG=1)'
      Caption = #35835#21462#21151#29575#21442#25968
    end
    object Action_Inventroy_6B: TAction
      Category = '18000-6B'
      Caption = #26597#35810#26631#31614
      OnExecute = Action_Inventroy_6BExecute
    end
    object Action_Query_6B: TAction
      Category = '18000-6B'
      Caption = #26597#35810#26631#31614
      OnExecute = Action_Query_6BExecute
    end
    object Action_WriteData_6B: TAction
      Category = '18000-6B'
      Caption = #20889#25968#25454
    end
    object Action_ReadData_6B: TAction
      Category = '18000-6B'
      Caption = #35835#25968#25454
    end
    object Action_LockByte_6B: TAction
      Category = '18000-6B'
      Caption = #38145#23450
      OnExecute = Action_LockByte_6BExecute
    end
    object Action_CheckLock_6B: TAction
      Category = '18000-6B'
      Caption = #26816#27979#38145#23450
      OnExecute = Action_CheckLock_6BExecute
      OnUpdate = Action_CheckLock_6BUpdate
    end
    object Action_Query2_6B: TAction
      Category = '18000-6B'
      Caption = 'Action_Query2_6B'
    end
    object Action_ShowOrChangeData_write: TAction
      Category = #21345#29255#25805#20316'(TAG=2)'
      Caption = #20889
      OnExecute = Action_ShowOrChangeDataExecuteExecute
    end
    object Action_ShowOrChangeData_BlockErase: TAction
      Category = #21345#29255#25805#20316'(TAG=2)'
      Caption = #22359#25830#38500
      OnExecute = Action_ShowOrChangeDataExecuteExecute
    end
    object Action_SetReadProtect_G2: TAction
      Category = #21345#29255#25805#20316'(TAG=2)'
      Caption = #35774#32622#21333#24352#35835#20445#25252
      OnExecute = Action_SetReadProtect_G2Execute
    end
    object Action_RemoveReadProtect_G2: TAction
      Category = #21345#29255#25805#20316'(TAG=2)'
      Caption = #35299#38500#21333#24352#35835#20445#25252
      OnExecute = Action_RemoveReadProtect_G2Execute
    end
    object Action_SetMultiReadProtect_G2: TAction
      Category = #21345#29255#25805#20316'(TAG=2)'
      Caption = #35774#32622#22810#24352#35835#20445#25252
      OnExecute = Action_SetMultiReadProtect_G2Execute
    end
    object Action_CheckReadProtected_G2: TAction
      Category = #21345#29255#25805#20316'(TAG=2)'
      Caption = #26816#27979#21333#24352#34987#35835#20445#25252#65288#19981#38656#35201#21345#21495#23494#30721#65289'       '
      OnExecute = Action_CheckReadProtected_G2Execute
    end
    object Action_SetEASAlarm_G2: TAction
      Category = #21345#29255#25805#20316'(TAG=2)'
      Caption = #35774#32622
      OnExecute = Action_SetEASAlarm_G2Execute
    end
    object Action_CheckEASAlarm_G2: TAction
      Category = #21345#29255#25805#20316'(TAG=2)'
      Caption = #26816#27979
    end
    object Action_WriteEPC_G2: TAction
      Category = #21345#29255#25805#20316'(TAG=2)'
      Caption = #20889'EPC'
      OnExecute = Action_WriteEPC_G2Execute
    end
    object Action_LockUserBlock_G2: TAction
      Category = #21345#29255#25805#20316'(TAG=2)'
      Caption = #38145#23450
    end
    object Action_WriteList: TAction
      Category = 'Inside'
      Caption = #21462#20540#20889#21442#25968
    end
    object Action_SolidifyPWMandPowerlist: TAction
      Category = 'Inside'
      Caption = #22266#21270'PWM'#20540#21644#21151#29575#34920
    end
    object Action_DeleteRfOutput: TAction
      Category = #20018#21475#25171#24320#21363#21487#25191#34892'(TAG=1)'
      Caption = #21024#38500#24378#21046'RF'#36755#20986
    end
    object Action_ShowOrChangeData_BlockWrite: TAction
      Category = #21345#29255#25805#20316'(TAG=2)'
      Caption = #22359#20889
      OnExecute = Action_ShowOrChangeDataExecuteExecute
    end
    object Action_TagProtocol: TAction
      Category = #20027#21160#27169#24335
      Caption = #35774#32622
    end
    object Action_Real: TAction
      Category = #20027#21160#27169#24335
      Caption = #32531#23384#25805#20316
      OnExecute = Action_RealExecute
      OnUpdate = Action_RealUpdate
    end
    object Action_Buff: TAction
      Category = #20027#21160#27169#24335
      Caption = #35835#21462#32531#23384
      OnExecute = Action_BuffExecute
      OnUpdate = Action_BuffUpdate
    end
  end
  object Timer_Buff: TTimer
    Enabled = False
    Interval = 50
    OnTimer = Timer_BuffTimer
    Left = 756
    Top = 280
  end
  object Timer_Mix: TTimer
    Enabled = False
    Interval = 20
    OnTimer = Timer_MixTimer
    Left = 748
    Top = 384
  end
end
