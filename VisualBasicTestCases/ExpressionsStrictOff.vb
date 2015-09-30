Option Strict Off

Imports BoolFuncExpression = System.Linq.Expressions.Expression(Of System.Func(Of Boolean))
Imports System.Runtime.CompilerServices

Public Class ExpressionsStrictOff

    ''' <summary>
    ''' x = y
    ''' </summary>
    Public Shared ReadOnly Property CompareObjectEqual As BoolFuncExpression
        Get
            Dim x As Object = True
            Dim y As Object = False
            Return Function() x = y
        End Get
    End Property

    ''' <summary>
    ''' x &lt;&gt; y
    ''' </summary>
    Public Shared ReadOnly Property CompareObjectNotEqual As BoolFuncExpression
        Get
            Dim x As Object = True
            Dim y As Object = True
            Return Function() x <> y
        End Get
    End Property
End Class
