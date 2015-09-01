Imports System.Drawing.Drawing2D

Public Class Tema2

End Class
'INSPIRERT AV https://creativemarket.com/ryanvsclark/7242-Flat-Stroke-UI-Kit
'Flat Stroke UI Kit av Ryan vs. Clark(https://creativemarket.com/ryanvsclark)


Class RundKnapp
    Inherits Control

#Region "Muspeikar stats"
    Dim MusPos1 As MusPos
    Enum MusPos As Byte
        Ingen = 0
        Over = 1
        Nede = 2
    End Enum

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        MusPos1 = MusPos.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        MusPos1 = MusPos.Nede
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        MusPos1 = MusPos.Over
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        MusPos1 = MusPos.Ingen
        Invalidate()
    End Sub
#End Region

    Private _knappFarger As Color()
    Public Property KnappFarger() As Color()
        Get
            Return _knappFarger
        End Get
        Set(ByVal value As Color())
            _knappFarger = value
        End Set
    End Property

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.UserPaint, True)
        Size = New Size(75, 23)
        KnappFarger = {Color.FromArgb(161, 161, 161), Color.FromArgb(94, 94, 94)}
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        'g.SmoothingMode = True

        'lage en figur som har formen til et rektangel, men med avrundete kanter. dette er formen til knappen
        Dim gPath As New GraphicsPath()
        gPath.StartFigure()

        gPath.AddLine(New Point(2, 0), New Point(75 - 2, 0)) 'Width - 4, 0))       -------
        gPath.AddLine(New Point(75 - 2, 0), New Point(75, 2))
        gPath.AddLine(New Point(75, 2), New Point(75, 20))
        gPath.AddLine(New Point(75, 20), New Point(73, 22))
        gPath.AddLine(New Point(73, 23), New Point(2, 23))
        gPath.AddLine(New Point(2, 23), New Point(0, 20))
        gPath.AddLine(New Point(0, 20), New Point(0, 2))
        gPath.AddLine(New Point(0, 2), New Point(2, 0))

        gPath.CloseFigure()

        Select Case MusPos1
            Case MusPos.Ingen
                g.FillPath(New SolidBrush(KnappFarger(0)), gPath)
                g.DrawString(Text, New Font("Arial", 10), Brushes.White, New Point(5, 4))
            Case MusPos.Over
                'må lage en ny gPath som er inni den andre
                Dim giPath As New GraphicsPath()
                giPath.StartFigure()

                giPath.AddLine(New Point(4, 2), New Point(75 - 4, 2)) 'Width - 4, 0))       -------
                giPath.AddLine(New Point(75 - 4, 2), New Point(73, 4))
                giPath.AddLine(New Point(73, 4), New Point(73, 18))
                giPath.AddLine(New Point(73, 18), New Point(71, 20))
                giPath.AddLine(New Point(71, 21), New Point(4, 21))
                giPath.AddLine(New Point(4, 21), New Point(2, 18))
                giPath.AddLine(New Point(2, 18), New Point(2, 4))
                giPath.AddLine(New Point(2, 4), New Point(4, 2))

                giPath.CloseFigure()

                g.FillPath(New SolidBrush(KnappFarger(0)), gPath)
                g.FillPath(Brushes.White, giPath)
                g.DrawString(Text, New Font("Arial", 10), New SolidBrush(KnappFarger(0)), New Point(5, 4))

            Case MusPos.Nede
                'må lage en ny gPath som er inni den andre
                Dim giPath As New GraphicsPath()
                giPath.StartFigure()

                giPath.AddLine(New Point(2, 2), New Point(75 - 2, 2)) 'Width - 4, 0))       -------
                giPath.AddLine(New Point(75 - 2, 2), New Point(75, 4))
                giPath.AddLine(New Point(75, 4), New Point(75, 20))
                giPath.AddLine(New Point(75, 20), New Point(73, 22))
                giPath.AddLine(New Point(73, 23), New Point(2, 23))
                giPath.AddLine(New Point(2, 23), New Point(0, 20))
                giPath.AddLine(New Point(0, 20), New Point(0, 4))
                giPath.AddLine(New Point(2, 2), New Point(4, 2))

                giPath.CloseFigure()

                g.FillPath(New SolidBrush(KnappFarger(1)), gPath) 'bakom
                g.FillPath(New SolidBrush(KnappFarger(0)), giPath) 'utenpå
                g.DrawString(Text, New Font("Arial", 10), Brushes.White, New Point(5, 4))
        End Select

        MyBase.OnPaint(e)
    End Sub
End Class