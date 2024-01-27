' ****************************************************************************************************************
' Form1.vb
' © 2023 - 2024 by Andreas Sauer
' ****************************************************************************************************************
'


Imports SchlumpfSoft.Controls.DriveWatcherControl

Public Class Form1


	Private Sub DriveWatcher1_DriveAdded(sender As Object, e As DriveAddedEventArgs) Handles DriveWatcher1.DriveAdded

		Me.Label2.Text = String.Format("Das Laufwerk {0} wurde hinzugefügt.", e.DriveName) & vbCrLf &
			String.Format("Der Datenträger hat die Bezeichnung {0} und ist vom Typ {1}.", e.VolumeLabel, e.DriveType) & vbCrLf &
			String.Format("Das Format ist {0} und er gesamte Speicherplatz beträgt {1} Bytes.", e.DriveFormat, e.TotalSize) & vbCrLf

		If e.IsReady Then

			Me.Label2.Text &= String.Format("Das Laufwerk ist bereit und der freie Speicherplatz beträgt {0} Bytes.", e.TotalFreeSpace)

		Else

			Me.Label2.Text &= "Das Laufwerk ist nicht bereit"

		End If


	End Sub


	Private Sub DriveWatcher1_DriveRemoved(sender As Object, e As DriveRemovedEventArgs) Handles DriveWatcher1.DriveRemoved

		Me.Label2.Text = String.Format("Das Laufwerk {0} wurde entfernt.", e.DriveName)

	End Sub


End Class
