unit UHFReader288MP_DLL_Head;

interface

Const

    UHFReader288MP_DLLName = 'UHFReader288MP.dll'; 

type
    RTempRecord=Record
    end;
     Function OpenNetPort(Port : LongInt;
                    IPaddr:string;
                     var ComAdr : byte;
                     var frmcomportindex:longint): LongInt; stdcall;external UHFReader288MP_DLLName ;
    Function CloseNetPort( frmComPortindex : longint ): LongInt; stdcall; external UHFReader288MP_DLLName ;

      Function OpenUSBPort(var ComAdr : byte;
                     var frmcomportindex:longint): LongInt; stdcall;external UHFReader288MP_DLLName ;
    Function CloseUSBPort( frmComPortindex : longint ): LongInt; stdcall; external UHFReader288MP_DLLName ;

    Function OpenComPort(Port : LongInt;
                          var ComAdr : byte;
                          Baud:byte;
                          var frmcomportindex: longint): LongInt;
                          stdcall; external UHFReader288MP_DLLName ;

    Function CloseComPort(): LongInt;
                         stdcall;external UHFReader288MP_DLLName ;

    Function AutoOpenComPort(var Port : longint;
                             var ComAdr : byte;
                             Baud:byte;
                             var frmComPortindex :longint ) : LongInt;
                             stdcall; external UHFReader288MP_DLLName ;

    Function CloseSpecComPort(frmComPortindex:longint): LongInt;
                              stdcall;external UHFReader288MP_DLLName ;

    Function GetReaderInformation(var ComAdr: byte;
                                  VersionInfo: pchar;
                                  var ReaderType: byte;
                                  var TrType: Byte;
                                  var dmaxfre ,dminfre,powerdBm:Byte;
                                  var ScanTime,Ant,BeepEn,OutputRep,CheckAnt: byte;
                                  frmComPortindex : longint): LongInt;
                                  stdcall; external UHFReader288MP_DLLName ;

    Function SetRegion(var ComAdr : byte;
                       dmaxfre : Byte;
                       dminfre : Byte;
                       frmComPortindex : longint): LongInt;
                       stdcall;external UHFReader288MP_DLLName ;

    Function SetAddress(var ComAdr : byte;
                         ComAdrData : Byte;
                         frmComPortindex : longint): LongInt;
                         stdcall; external UHFReader288MP_DLLName ;

    Function SetInventoryScanTime(var ComAdr : byte;
                           ScanTime : Byte;
                           frmComPortindex : longint): LongInt;
                           stdcall;external UHFReader288MP_DLLName ;

    Function InSelfTestMode(var ComAdr:Byte;
                            IsSelfTestMode:Boolean;
                            frmComPortindex : longint ): LongInt;
                            stdcall;external UHFReader288MP_DLLName ;

    Function SetBaudRate(var ComAdr : byte;
                       baud : Byte;
                       frmComPortindex : longint): LongInt;
                       stdcall; external UHFReader288MP_DLLName ;

    Function SetDAC(var ComAdr : byte;
                    DACdata : Byte;
                    frmComPortindex : longint): LongInt;
                    stdcall; external UHFReader288MP_DLLName ;

    Function GetDAC(var ComAdr : byte;
                     var DACdata : Byte;
                     frmComPortindex : longint): LongInt;
                     stdcall; external UHFReader288MP_DLLName ;

    Function CheckPowerParameter(var ComAdr : byte;
                                 var code:longint;
                                 frmComPortindex : longint): LongInt;
                                 stdcall; external UHFReader288MP_DLLName ;

    Function SolidifyDACandPowerlist(var ComAdr:Byte;
                                     dBm_list:PChar;
                                     var code:LongInt;
                                     frmcomportindex: longint): LongInt;
                                     stdcall; external UHFReader288MP_DLLName ;

    Function GetStartInformation(var ComAdr : byte;
                                 var FreE,addrE,scnE,xpwrE,wgE,xRreadModeE,xModeParaE,xbpsE,xEasAccuE:Byte;
                                 frmComPortindex : longint): LongInt;
                                 stdcall; external UHFReader288MP_DLLName ;

    Function SetRfPower(var ComAdr : byte;
                         powerDbm : Byte;
                         frmComPortindex : longint): LongInt;
                         stdcall; external UHFReader288MP_DLLName ;

    Function RfOutput(var ComAdr : byte;
                      onoff : Byte;
                      frmComPortindex : longint): LongInt;
                      stdcall; external UHFReader288MP_DLLName ;

    Function DeleteRfOutput(var ComAdr : byte;
                            var Reinfo : Byte;
                            frmComPortindex : longint): LongInt;
                            stdcall; external UHFReader288MP_DLLName ;

     function BuzzerAndLEDControl(var ComAdr:Byte;
                                 AvtiveTime:Byte;
                                 SilentTime:Byte;
                                 Times:Byte;
                                 frmComPortindex: LongInt):LongInt;
                                 stdcall;external UHFReader288MP_DLLName ;

    function SetWorkMode(var ComAdr:Byte;
                         Read_mode:Byte;
                         frmComPortindex : longint): LongInt;
                         stdcall;external UHFReader288MP_DLLName ;

    function GetSystemParameter(var ComAdr:Byte;
                                 var Read_mode,Accuracy,RepCondition,RepPauseTime,ReadPauseTim,TagProtocol,MaskMem:Byte;
                                 MaskAdr:PChar;
							                   var MaskLen:Byte;
							                   MaskData:PChar;
                                 var TriggerTime,AdrTID,LenTID:Byte;
                                 frmComPortindex : longint): LongInt;
                                 stdcall;external UHFReader288MP_DLLName ;

    Function SetEASSensitivity(var ComAdr:Byte;
                         Accuracy:Byte;
                         frmComPortindex: longint):LongInt;
                         stdcall;external UHFReader288MP_DLLName ;

    Function SetTriggerTime(var ComAdr:Byte;
                         TriggerTime:Byte;
                         frmComPortindex: longint):LongInt;
                         stdcall;external UHFReader288MP_DLLName ;

    function SetMask(var ComAdr:Byte;
                     MaskMem:Byte;
                     MaskAdr:PChar;
                     MaskLen:Byte;
                     MaskData:PChar;
                     frmComPortindex: longint):LongInt;
                     stdcall;external UHFReader288MP_DLLName ;

    function SetResponsePamametersofAuto_runningMode(var ComAdr:Byte;
                             RepCondition:Byte;
                             RepPauseTime:Byte;
                             frmComPortindex: longint):LongInt;
                             stdcall;external UHFReader288MP_DLLName ;

    function SetInventoryInterval(var ComAdr:Byte;
                             ReadPauseTim:Byte;
                             frmComPortindex: longint):LongInt;
                             stdcall;external UHFReader288MP_DLLName ;

    function SelectTagType(var ComAdr:Byte;
                             Protocol:Byte;
                             frmComPortindex: longint):LongInt;
                             stdcall;external UHFReader288MP_DLLName ;

    function SetAntennaMultiplexing(var ComAdr:Byte;
                             Ant:Byte;
                             frmComPortindex: longint):LongInt;
                             stdcall;external UHFReader288MP_DLLName ;

    function SetBeepNotification(var ComAdr:Byte;
                     BeepEn:Byte;
                     frmComPortindex: longint):LongInt;
                     stdcall;external UHFReader288MP_DLLName ;

    function SetReal_timeClock(var ComAdr:Byte;
                     paramer:pchar;
                     frmComPortindex: longint):LongInt;
                     stdcall;external UHFReader288MP_DLLName ;

    function GetTime(var ComAdr:Byte;
                     paramer:pchar;
                     frmComPortindex: longint):LongInt;
                     stdcall;external UHFReader288MP_DLLName ;

    function GetTagBufferInfo(var ComAdr:Byte;
                               Data:pchar;
                               var dataLength:LongInt;
                               frmComPortindex: longint):LongInt;
                               stdcall;external UHFReader288MP_DLLName ;

    function ClearTagBuffer(var ComAdr:Byte;
                     frmComPortindex: longint):LongInt;
                     stdcall;external UHFReader288MP_DLLName ;

    Function SetRelay(var ComAdr : byte;
                     RelayTime: Byte;
                     frmComPortindex : longint): LongInt;
                     stdcall; external UHFReader288MP_DLLName ;

   function SetRevDelay(var ComAdr:Byte;
                     RevDelay:Byte;
                     frmComPortindex: longint):LongInt;
                     stdcall;external UHFReader288MP_DLLName ;

    function GetRevDelay(var ComAdr:Byte;
                     var RevDelay:Byte;
                     frmComPortindex: longint):LongInt;
                     stdcall;external UHFReader288MP_DLLName ;

    function SetGPIO(var ComAdr:Byte;
                     OutputPin:Byte;
                     frmComPortindex: longint):LongInt;
                     stdcall;external UHFReader288MP_DLLName ;

    function GetGPIOStatus(var ComAdr:Byte;
                     var OutputPin:Byte;
                     frmComPortindex: longint):LongInt;
                     stdcall;external UHFReader288MP_DLLName ;

    function SetNotificationPulseOutput(var ComAdr:Byte;
                     OutputRep:Byte;
                     frmComPortindex: longint):LongInt;
                     stdcall;external UHFReader288MP_DLLName ;

    Function ReadActiveModeData(ScanModeData: pchar;
                                Var ValidDatalength: longint;
                                frmComPortindex: longint): LongInt;
                                Stdcall;external UHFReader288MP_DLLName ;

     function SetTIDParameter(var ComAdr:Byte;
                     AdrTID,LenTID:Byte;
                     frmComPortindex: longint):LongInt;
                     stdcall;external UHFReader288MP_DLLName ;

     function GetSeriaNo(var ComAdr:Byte;
                     SeriaNo:PChar;
                     frmComPortindex: longint):LongInt;
                     stdcall;external UHFReader288MP_DLLName ;

     function ChangeATMode(var ComAdr:Byte;
                     ATMode:Byte;
                     frmComPortindex: longint):LongInt;
                     stdcall;external UHFReader288MP_DLLName ;

    function TransparentCMD(var ComAdr:Byte;
                     timeout:Byte;
                     nlen:Byte;
                     cmddata:PChar;
                     var recvLen:Byte;
                     recvdata:PChar;
                     frmComPortindex: longint):LongInt;
                     stdcall;external UHFReader288MP_DLLName ;

    function SetFlashRom(var ComAdr:Byte;
                     frmComPortindex: longint):LongInt;
                     stdcall;external UHFReader288MP_DLLName ;

     function GetModuleVersion(var ComAdr:Byte;
                     Version:PChar;
                     frmComPortindex: longint):LongInt;
                     stdcall;external UHFReader288MP_DLLName ;

//EPC  G2
     Function Inventory_G2(var ComAdr:Byte;
                          QValue,Session:Byte;
                          MaskMem:Byte;
                          MaskAdr:PChar;
                          MaskLen:Byte;
                          MaskData:PChar;
                          MaskFlag,AdrTID,LenTID,TIDFlag,Target,InAnt,Scantime,FastFlag:Byte;

                          pEPCList:PChar;
                          var Ant:Byte;
                          var Totallen:LongInt;
                          var CardNum:LongInt;
							            frmComPortindex : longint): LongInt;
                          stdcall; external UHFReader288MP_DLLName ;
    Function InventoryMix_G2(var ComAdr:Byte;
                          QValue,Session:Byte;
                          MaskMem:Byte;
                          MaskAdr:PChar;
                          MaskLen:Byte;
                          MaskData:PChar;
                          MaskFlag,ReadMem:Byte;
                          ReadAdr:PChar;
                          ReadLen:Byte;
                          Psd:PChar;
                          Target,InAnt,Scantime,FastFlag:Byte;
                          pEPCList:PChar;
                          var Ant:Byte;
                          var Totallen:LongInt;
                          var CardNum:LongInt;
							            frmComPortindex : longint): LongInt;
                          stdcall; external UHFReader288MP_DLLName ;

    Function  ReadData_G2(var ComAdr:Byte;
                          EPC:PChar;
                          ENum:Byte;
                          Mem:Byte;
                          WordPtr:Byte;
                          Num:Byte;
                          Password:PChar;
                          MaskMem:Byte;
                          MaskAdr:PChar;
                          MaskLen:Byte;
                          MaskData:PChar;
                          Data:PChar;
                          var errorcode:longint;
                          frmComPortindex : longint ): LongInt;
                          stdcall;external UHFReader288MP_DLLName ;

    Function WriteData_G2(var ComAdr:Byte;
                          EPC:PChar;
                          WNum:Byte;
                          ENum:Byte;
                          Mem:Byte;
                          WordPtr:Byte;
                          Wdt:PChar;
                          Password:PChar;
                          MaskMem:Byte;
                          MaskAdr:PChar;
                          MaskLen:Byte;
                          MaskData:PChar;
                          var errorcode:longint;
                          frmComPortindex : longint ): LongInt;
                          stdcall;external UHFReader288MP_DLLName ;

     Function WriteEPC_G2(var ComAdr:Byte;
                          Password:PChar;
                          WriteEPC:PChar;
                          ENum:byte;
                          var errorcode:longint;
                          frmComPortindex : longint ): LongInt;
                          stdcall;external UHFReader288MP_DLLName ;

     Function KillTag_G2(var ComAdr:Byte;
                            EPC:PChar;
                            ENum:Byte;
                            Password:PChar;
                            MaskMem:Byte;
                            MaskAdr:PChar;
                            MaskLen:Byte;
                            MaskData:PChar;
                            var errorcode:longint;
                            frmComPortindex : longint ): LongInt;
                            stdcall;external UHFReader288MP_DLLName ;

    Function Lock_G2(var ComAdr:Byte;
                            EPC:PChar;
                            ENum:Byte;
								            select:byte;
                            setprotect:Byte;
                            Password:PChar;
                            MaskMem:Byte;
                            MaskAdr:PChar;
                            MaskLen:Byte;
                            MaskData:PChar;
                            var errorcode:longint;
                            frmComPortindex : longint ): LongInt;
                            stdcall;external UHFReader288MP_DLLName ;

    Function BlockErase_G2(var ComAdr:Byte;
                          EPC:PChar;
                          ENum:Byte;
                          Mem:Byte;
                          WordPtr:Byte;
                          Num:Byte;
                          Password:PChar;
                          MaskMem:Byte;
                          MaskAdr:PChar;
                          MaskLen:Byte;
                          MaskData:PChar;
                          var errorcode:longint;
                          frmComPortindex : longint ): LongInt;
                          stdcall;external UHFReader288MP_DLLName ;

    Function SetPrivacyWithoutEPC_G2(var ComAdr:Byte;
                                    Password:PChar;
                                    var errorcode:longint;
                                    frmComPortindex : longint ): LongInt;
                                    stdcall;external UHFReader288MP_DLLName ;

    Function SetPrivacyByEPC_G2(var ComAdr:Byte;
                                EPC:PChar;
                                ENum:Byte;
                                Password:PChar;
                                MaskMem:Byte;
                                MaskAdr:PChar;
                                MaskLen:Byte;
                                MaskData:PChar;
                                var errorcode:longint;
                                frmComPortindex : longint ): LongInt;
                                stdcall;external UHFReader288MP_DLLName ;

    Function ResetPrivacy_G2(var ComAdr:Byte;
                                  Password:PChar;
                                  var errorcode:longint;
                                  frmComPortindex : longint ): LongInt;
                                  stdcall;external UHFReader288MP_DLLName ;

    Function CheckPrivacy_G2(var ComAdr:Byte;
                                   var readpro:byte;
                                   var errorcode:longint;
                                   frmComPortindex : longint ): LongInt;
                                   stdcall;external UHFReader288MP_DLLName ;

    Function EASConfigure_G2(var ComAdr:Byte;
                            EPC:PChar;
                            ENum:Byte;
                            Password:PChar;
                            EAS:Byte;
                            MaskMem:Byte;
                            MaskAdr:PChar;
                            MaskLen:Byte;
                            MaskData:PChar;
                            var errorcode:longint;
                            frmComPortindex : longint ): LongInt;
                            stdcall;external UHFReader288MP_DLLName ;

    Function EASAlarm_G2(var ComAdr:Byte;
                              var errorcode:longint;
                              frmComPortindex : longint ): LongInt;
                              stdcall;external UHFReader288MP_DLLName ;

    Function BlockLock_G2(var ComAdr:Byte;
                              EPC:PChar;
                              ENum:Byte;
                              Password:PChar;
                              WrdPointer:Byte;
                              MaskMem:Byte;
                              MaskAdr:PChar;
                              MaskLen:Byte;
                              MaskData:PChar;
                              var errorcode:longint;
                              frmComPortindex : longint ): LongInt;
                              stdcall;external UHFReader288MP_DLLName ;

    Function BlockWrite_G2(var ComAdr:Byte;
                          EPC:PChar;
                          WNum:Byte;
                          ENum:Byte;
                          Mem:Byte;
                          WordPtr:Byte;
                          Wdt:PChar;
                          Password:PChar;
                          MaskMem:Byte;
                          MaskAdr:PChar;
                          MaskLen:Byte;
                          MaskData:PChar;
                          var errorcode:longint;
                          frmComPortindex : longint ): LongInt;
                          stdcall;external UHFReader288MP_DLLName ;

    Function SingleTagInventory_G2(var ComAdr:Byte;
                          EPC:PChar;
                          var EPCLength:longint;
                          var CardNum:longint;
                          frmComPortindex : longint ): LongInt;
                          stdcall;external UHFReader288MP_DLLName ;



//18000_6B

  Function InventorySingle_6B(var ComAdr : byte;
                        var Ant:Byte;
                        ID_6B : pchar;
                        frmComPortindex:LongInt): LongInt;
                        stdcall; external UHFReader288MP_DLLName ;

  Function InventoryMultiple_6B(var ComAdr : byte;
                         Condition,StartAddress,mask:byte;
                         ConditionContent:PChar;
                         var Ant:Byte;
                         ID_6B : pchar;
                         var Cardnum:longint;
                         frmComPortindex:LongInt): LongInt;
                         stdcall; external UHFReader288MP_DLLName ;

  Function ReadData_6B(var ComAdr:Byte;
                       ID_6B:PChar;
                       StartAddress,Num:Byte;
                       Data:PChar;
                       var errorcode:longint;
                       frmComPortindex : longint ): LongInt;
                       stdcall;external UHFReader288MP_DLLName ;

  Function WriteData_6B(var ComAdr:Byte;
                        ID_6B:PChar;
                        StartAddress:Byte;
                        Writedata:PChar;
                        Writedatalen:Byte;
                        var writtenbyte:longint;
                        var errorcode:longint;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;

  Function Lock_6B(var ComAdr:Byte;
                       ID_6B:PChar;
                       Address:Byte;
                       var errorcode:longint;
                       frmComPortindex : longint ): LongInt;
                       stdcall;external UHFReader288MP_DLLName ;

  Function CheckLock_6B(var ComAdr:Byte;
                        ID_6B:PChar;
                        Address:Byte;
                        var ReLockState:Byte;
                        var errorcode:longint;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;

   /////ÐÂÔöÃüÁî
   Function EnableTestFreq(var ComAdr:Byte;
                        TestFreq:PChar;
                        GainIndex:Byte;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;

   Function SetAValue(var ComAdr:Byte;
                        nFlag:Byte;
                        A1:PChar;
                        A0:PChar;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;

   Function GetADValue(var ComAdr:Byte;
                        nFlag:Byte;
                        ADValue:PChar;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;

   Function AutoTable(var ComAdr:Byte;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;

   Function AutoOffset(var ComAdr:Byte;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;

   Function GetAdjustPara(var ComAdr:Byte;
                        Data:PChar;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;

   Function SetCheckAnt(var ComAdr:Byte;
                        CheckAnt:Byte;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;

   Function GetCheckPWR(var ComAdr:Byte;
                        FWDPWR:PChar;
                        REVPWR:PChar;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;


    Function SetCommType(var ComAdr:Byte;
                        CommType:Byte;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;

    Function SetTagCustomFunction(var ComAdr:Byte;
                        var InlayType:Byte;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;

    Function SetMonza4QTWorkParamter_G2(var ComAdr:Byte;
                          EPC:PChar;
                          ENum:Byte;
                          QTcontrol:Byte;
                          Password:PChar;
                          MaskMem:Byte;
                          MaskAdr:PChar;
                          MaskLen:Byte;
                          MaskData:PChar;
                          var errorcode:longint;
                          frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;

     Function GetMonza4QTWorkParamter_G2(var ComAdr:Byte;
                          EPC:PChar;
                          ENum:Byte;
                          Password:PChar;
                          MaskMem:Byte;
                          MaskAdr:PChar;
                          MaskLen:Byte;
                          MaskData:PChar;
                          var QTcontrol:Byte;
                          var errorcode:longint;
                          frmComPortindex : longint ): LongInt;
                          stdcall;external UHFReader288MP_DLLName ;

     Function SetQS(var ComAdr:Byte;
                        QValue:Byte;
                        Session:Byte;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;

     Function GetQS(var ComAdr:Byte;
                    var QValue:Byte;
                    var Session:Byte;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;

    Function  ExtReadData_G2(var ComAdr:Byte;
                          EPC:PChar;
                          ENum:Byte;
                          Mem:Byte;
                          WordPtr:PChar;
                          Num:Byte;
                          Password:PChar;
                          MaskMem:Byte;
                          MaskAdr:PChar;
                          MaskLen:Byte;
                          MaskData:PChar;
                          Data:PChar;
                          var errorcode:longint;
                          frmComPortindex : longint ): LongInt;
                          stdcall;external UHFReader288MP_DLLName
                          
    Function ExtWriteData_G2(var ComAdr:Byte;
                          EPC:PChar;
                          WNum:Byte;
                          ENum:Byte;
                          Mem:Byte;
                          WordPtr:PChar;
                          Wdt:PChar;
                          Password:PChar;
                          MaskMem:Byte;
                          MaskAdr:PChar;
                          MaskLen:Byte;
                          MaskData:PChar;
                          var errorcode:longint;
                          frmComPortindex : longint ): LongInt;
                          stdcall;external UHFReader288MP_DLLName ;

   Function SetReadMode(var ComAdr:Byte;
                        ReadMode:Byte;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;

   Function SetReadParameter(var ComAdr:Byte;
                        Parameter:PChar;
                        MaskMem:Byte;
                        MaskAdr:PChar;
                        MaskLen:Byte;
                        MaskData:PChar;
                        MaskFlag,AdrTID,LenTID,TIDFlag:Byte;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;

   Function GetReadParameter(var ComAdr:Byte;
                        Parameter:PChar;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;

  Function InventoryBuffer_G2(var ComAdr:Byte;
                          QValue,Session:Byte;
                          MaskMem:Byte;
                          MaskAdr:PChar;
                          MaskLen:Byte;
                          MaskData:PChar;
                          MaskFlag,AdrTID,LenTID,TIDFlag,Target,InAnt,Scantime,FastFlag:Byte;
                          var BufferCount:LongInt;
                          var TagNum:LongInt;
							            frmComPortindex : longint): LongInt;
                          stdcall; external UHFReader288MP_DLLName ;

    Function SetSaveLen(var ComAdr:Byte;
                        SaveLen:Byte;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;
    Function GetSaveLen(var ComAdr:Byte;
                        var SaveLen:Byte;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;
    Function ReadBuffer_G2(var ComAdr:Byte;
                          var Totallen:LongInt;
                          var CardNum:longint;
                          pEPCList:PChar;
                          frmComPortindex : longint ): LongInt;
                          stdcall;external UHFReader288MP_DLLName ;
    Function ClearBuffer_G2(var ComAdr:Byte;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;
    Function GetBufferCnt_G2(var ComAdr:Byte;
                        var Count:LongInt;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;

    Function WriteRfPower(var ComAdr:Byte;
                        powerDbm:Byte;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;

    Function ReadRfPower(var ComAdr:Byte;
                        var powerDbm:Byte;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;

    Function RetryTimes(var ComAdr:Byte;
                        var Times:Byte;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;

    Function SetDRM(var ComAdr:Byte;
                        DRM:Byte;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;
                        
    Function GetDRM(var ComAdr:Byte;
                        var DRM:Byte;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;

     Function GetReaderTemperature(var ComAdr:Byte;
                        var PlusMinus,Temperature:Byte;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;

    Function MeasureReturnLoss(var ComAdr:Byte;
                        TestFreq:PChar;
                        Ant:Byte;
                        var ReturnLoss:Byte;
                        frmComPortindex : longint ): LongInt;
                        stdcall;external UHFReader288MP_DLLName ;


implementation

end.
