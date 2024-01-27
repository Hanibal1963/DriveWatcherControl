'
'****************************************************************************************************************
'NativeForm.vb
'© 2023 - 2024 by Andreas Sauer
'****************************************************************************************************************
'

Imports System.Windows.Forms
Imports System.IO


Friend Class NativeForm

	Inherits NativeWindow


	'Das sind die Ereignisse aus WParam.
	'Uns interessiert nur, ob ein Laufwerk hinzugekommen ist oder entfernt wurde.
	Public Event DriveAdded(sender As Object, e As DriveInfo)
	Public Event DriveRemoved(sender As Object, e As DriveInfo)


	'Windowmessage DeviceChange
	Private Const WM_DEVICECHANGE As Integer = &H219


	'Die beiden Ereignisse, die für uns von Bedeutung sind.
	Private Const DBT_DEVICEARRIVAL As Integer = &H8000
	Private Const DBT_DEVICEREMOVECOMPLETE As Integer = &H8004


	'Dies ist der Dreh- und Angelpunkt der Klasse. - Hier bekommen wir die Messages mit.
	'In unserm Fall interessiert uns nur die WM_DeviceChange-Nachricht
	Protected Overrides Sub WndProc(ByRef m As Message)

		If m.Msg = WM_DEVICECHANGE Then
			Me.HandleHeader(m)
		End If
		MyBase.WndProc(m)

	End Sub


	'Hier schauen wir erst mal in den Header und verzweigen dementsprechend
	Private Sub HandleHeader(ByRef m As Message)

		Dim header As DEV_BROADCAST_HDR
		Dim objHeader As Object = m.GetLParam(header.GetType)

		If Not Microsoft.VisualBasic.IsNothing(objHeader) Then

			Select Case header.dbch_devicetype

				Case DBT_DEVTYP.OEM : Me.HandleOEM(m)
				Case DBT_DEVTYP.DEVNODE
				Case DBT_DEVTYP.VOLUME : Me.HandleVolume(m)
				Case DBT_DEVTYP.PORT
				Case DBT_DEVTYP.NET
				Case DBT_DEVTYP.DEVICEINTERFACE
				Case DBT_DEVTYP.HANDLE

			End Select

		End If

	End Sub


	'Das Ereignis betrifft ein Volume
	Private Sub HandleVolume(ByRef m As Message)

		Dim volume As DEV_BROADCAST_VOLUME
		Dim objVolume As Object = m.GetLParam(volume.GetType)

		If Not Microsoft.VisualBasic.IsNothing(objVolume) Then

			volume = DirectCast(objVolume, DEV_BROADCAST_VOLUME)
			Dim di As New DriveInfo(Me.DriveFromMask(volume.dbcv_unitmask))

			Select Case CInt(m.WParam)

				Case DBT_DEVICEARRIVAL : RaiseEvent DriveAdded(Me, di)
				Case DBT_DEVICEREMOVECOMPLETE : RaiseEvent DriveRemoved(Me, di)

			End Select




		End If

	End Sub


	'OEM, und was genau?
	'Uns interesieren nur Volumes
	Private Sub HandleOEM(ByRef m As Message)

		Dim oem As DEV_BROADCAST_OEM
		Dim objOem As Object = m.GetLParam(oem.GetType)

		If Not Microsoft.VisualBasic.IsNothing(objOem) Then

			oem = DirectCast(objOem, DEV_BROADCAST_OEM)

			If oem.dbco_devicetype = DBT_DEVTYP.VOLUME Then
				Me.HandleVolume(m)
			End If

		End If

	End Sub


	'Liefert den Laufwerksbuchstaben zurück
	Private Function DriveFromMask(mask As Integer) As Char

		Dim result As Char = CChar(String.Empty)

		For b As Integer = 0 To 25

			If (mask And CInt(2 ^ b)) <> 0 Then
				result = Microsoft.VisualBasic.Chr(65 + b)
				Exit For
			End If

		Next b

		Return result

	End Function


	Public Sub New()

		'eigenes Handle erstellen
		Me.CreateHandle(New CreateParams)

	End Sub


	Protected Overrides Sub Finalize()

		'eigenes Handle zerstören
		Me.DestroyHandle()
		MyBase.Finalize()

	End Sub


End Class


