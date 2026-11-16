Imports System

Namespace VBLibrary
    Public Class Person
        Public Property Name As String
        Public Property Age As Integer

        Public Sub New(name As String, age As Integer)
            Me.Name = name
            Me.Age = age
        End Sub

        Public Overridable Sub DisplayInfo()
            Console.WriteLine("[VB.NET DLL Base Class: Person]")
            Console.WriteLine("  Name : " & Name)
            Console.WriteLine("  Age  : " & Age)
        End Sub

        Public Overridable Function GetRole() As String
            Return "Base Person (Defined in VB DLL)"
        End Function
    End Class
End Namespace
