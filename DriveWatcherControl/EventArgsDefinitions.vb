' ****************************************************************************************************************
' EventArgsDefinitions.vb
' © 2023 - 2024 by Andreas Sauer
' ****************************************************************************************************************
'

Public Structure DriveAddedEventArgs


	''' <summary>
	''' Ruft den Namen eines Laufwerks ab, z.B. C:\.
	''' </summary>
	''' <returns></returns>
	Public Property DriveName As String


	''' <summary>
	''' Ruft die Volumebezeichnung eines Laufwerks ab oder legt diese fest.
	''' </summary>
	''' <returns></returns>
	Public Property VolumeLabel As String


	''' <summary>
	''' Gibt die Gesamtmenge an verfügbarem freiem Speicherplatz in Bytes an, die auf einem Laufwerk verfügbar ist.
	''' </summary>
	''' <returns></returns>
	Public Property AvailableFreeSpace As Long


	''' <summary>
	''' Ruft die Gesamtmenge an freiem Speicherplatz in Bytes ab, die auf einem Laufwerk verfügbar ist.
	''' </summary>
	''' <returns></returns>
	Public Property TotalFreeSpace As Long

	''' <summary>
	''' Ruft die Gesamtgröße des Speicherplatzes in Bytes auf einem Laufwerk ab.
	''' </summary>
	''' <returns></returns>
	Public Property TotalSize As Long


	''' <summary>
	''' Ruft den Namen des Dateisystems ab, z. B. NTFS oder FAT32.
	''' </summary>
	''' <returns></returns>
	Public Property DriveFormat As String


	''' <summary>
	''' Ruft den Laufwerkstyp ab, wie z. B. CD-ROM, Wechseldatenträger, Netzlaufwerk oder lokales Festplattenlaufwerk.
	''' </summary>
	''' <returns></returns>
	Public Property DriveType As System.IO.DriveType


	''' <summary>
	''' Ruft einen Wert ab, der angibt, ob ein Laufwerk bereit ist.
	''' </summary>
	''' <returns></returns>
	Public Property IsReady As Boolean


End Structure

Public Structure DriveRemovedEventArgs


	''' <summary>
	''' Ruft den Namen eines Laufwerks ab, z.B. C:\.
	''' </summary>
	''' <returns></returns>
	Public Property DriveName As String


End Structure
