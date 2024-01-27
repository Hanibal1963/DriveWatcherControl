'
'****************************************************************************************************************
'DriveWatcher.vb
'(c) 2023 by Andreas Sauer
'****************************************************************************************************************
'

Imports System.ComponentModel
Imports System.Drawing

<ProvideToolboxControl("SchlumpfSoft", False)>
<ToolboxItem(True)>
<Description("Steuerelement um die Laufwerke zu überwachen.")>
<ToolboxBitmap(GetType(DriveWatcher), "DriveWatcher.bmp")>
Public Class DriveWatcher

    Inherits Component

    Private WithEvents _Form As New NativeForm

    ''' <summary>
    ''' Wird ausgelöst wenn ein Laufwerk hinzugefügt wurde.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e">
    ''' Enthält die Eigenschaften zum hinzugefügten Laufwerk. (<see cref="DriveAddedEventArgs"/>)
    ''' </param>
    Public Event DriveAdded(sender As Object, e As DriveAddedEventArgs)

    ''' <summary>
    ''' Wird ausgelöst wenn ein Laufwerk entfernt wurde.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e">
    ''' Enthält die eigenschaften zum entfernten Laufwerk. (<see cref="DriveRemovedEventArgs"/>)
    ''' </param>
    Public Event DriveRemoved(sender As Object, e As DriveRemovedEventArgs)


    ''' <summary>
    ''' wird ausgeführt wenn ein Laufwerk hinzugefügt wurde.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e">
    ''' Enthält Informationen über das Laufwerk.
    ''' </param>
    Private Sub _Form_DriveAdded(sender As Object, e As System.IO.DriveInfo) Handles _Form.DriveAdded

        Dim arg As New DriveAddedEventArgs With {
            .DriveName = e.Name, .VolumeLabel = e.VolumeLabel, .AvailableFreeSpace = e.AvailableFreeSpace,
            .TotalFreeSpace = e.TotalFreeSpace, .TotalSize = e.TotalSize, .DriveFormat = e.DriveFormat,
            .DriveType = e.DriveType, .IsReady = e.IsReady}

        RaiseEvent DriveAdded(Me, arg)

    End Sub


    ''' <summary>
    ''' wird ausgeführt wenn ein Laufwerk entfernt wurde.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e">
    ''' Enthält Informationen über das Laufwerk.
    ''' </param>
    Private Sub _Form_DriveRemoved(sender As Object, e As System.IO.DriveInfo) Handles _Form.DriveRemoved

        Dim arg As New DriveRemovedEventArgs With {.DriveName = e.Name}

        RaiseEvent DriveRemoved(Me, arg)

    End Sub

End Class
