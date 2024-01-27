' ****************************************************************************************************************
' StructureDefinitions.vb
' © 2023 - 2024 by Andreas Sauer
' ****************************************************************************************************************
'

''' <summary>
''' Das sind die Konstanten der Gerätetypen
''' </summary>
''' <remarks>
''' Vorsicht die Gerätetypen Variablen in den Strukturen sind vom Typ Integer.
''' IntelliSense kann das nicht auflösen.
''' </remarks>
Friend Enum DBT_DEVTYP

	''' <summary>
	''' OEM- oder IHV-definiert
	''' </summary>
	OEM = 0

	''' <summary>
	''' Devnode-Nummer
	''' </summary>
	DEVNODE = 1

	''' <summary>
	''' Logisches Volumen
	''' </summary>
	VOLUME = 2

	''' <summary>
	''' Port (seriell oder parallel)
	''' </summary>
	PORT = 3

	''' <summary>
	''' Netzwerkressource
	''' </summary>
	NET = 4

	''' <summary>
	''' Geräteschnittstellenklasse
	''' </summary>
	DEVICEINTERFACE = 5

	''' <summary>
	''' Dateisystem-Handle
	''' </summary>
	HANDLE = 6

End Enum

''' <summary>
''' Die Struktur für den Header.
''' </summary>
''' <remarks>
''' https://learn.microsoft.com/de-de/windows/win32/api/dbt/ns-dbt-dev_broadcast_hdr
''' </remarks>
Friend Structure DEV_BROADCAST_HDR

	Dim dbch_size As Integer
	Dim dbch_devicetype As Integer
	Dim dbch_reserved As Integer

End Structure

''' <summary>
''' Die Struktur für OEM.
''' </summary>
''' <remarks>
''' https://learn.microsoft.com/de-de/windows/win32/api/dbt/ns-dbt-dev_broadcast_oem
''' </remarks>
Friend Structure DEV_BROADCAST_OEM

	Dim dbco_size As Integer
	Dim dbco_devicetype As Integer
	Dim dbco_reserved As Integer
	Dim dbco_identifier As Integer
	Dim dbco_suppfunc As Integer

End Structure

''' <summary>
''' Die Struktur für Volumes.
''' </summary>
''' <remarks>
''' https://learn.microsoft.com/de-de/windows/win32/api/dbt/ns-dbt-dev_broadcast_volume
''' </remarks>
Friend Structure DEV_BROADCAST_VOLUME

	Dim dbch_size As Integer
	Dim dbch_devicetype As Integer
	Dim dbch_reserved As Integer
	Dim dbcv_unitmask As Integer
	Dim dbcv_flags As Short

End Structure
