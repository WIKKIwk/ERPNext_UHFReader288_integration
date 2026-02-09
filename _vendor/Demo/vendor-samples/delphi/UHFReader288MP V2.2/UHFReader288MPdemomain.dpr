program UHFReader288MPdemomain;



uses
  Forms,
  frmUHFReader288MPdemomain in 'frmUHFReader288MPdemomain.pas' {frmUHFReader288MPmain},
  UHFReader288MP_Head in 'UHFReader288MP_Head.pas',
  UHFReader288MP_DLL_Head in 'UHFReader288MP_DLL_Head.pas',
  fProgressbar in 'fProgressbar.pas' {frmprogress},
  LoginForm in 'LoginForm.pas' {fLoginForm},
  DevControl in 'DevControl.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TfrmUHFReader288MPmain, frmUHFReader288MPmain);
  Application.CreateForm(Tfrmprogress, frmprogress);
  Application.CreateForm(TfLoginForm, fLoginForm);
  Application.Run;
end.
