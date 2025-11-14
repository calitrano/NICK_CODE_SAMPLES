<#powershell to show popup box
end comment #>

$wshell = New-Object -ComObject Wscript.Shell

$wshell.Popup("Hey Nick its Powershell ",0,"Done",0x1)


$wshell.Popup("Welcome $Env:ComputerName Your network drives are mounted",5,"Mappning")


Add-Type -AssemblyName Microsoft.VisualBasic
[Microsoft.VisualBasic.Interaction]::MsgBox('Hello Nick',1,'Nicks Message box')
[Microsoft.VisualBasic.Interaction]::InputBox('Enter you name:', 'User Inforation','Joe Smith')
