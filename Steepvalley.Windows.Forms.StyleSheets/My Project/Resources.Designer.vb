﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("Steepvalley.Windows.Forms.Styles.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to WindowsForm Stylesheet.
        '''</summary>
        Friend ReadOnly Property ApplicationTitle() As String
            Get
                Return ResourceManager.GetString("ApplicationTitle", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Assembly.
        '''</summary>
        Friend ReadOnly Property AssemblyColHeader() As String
            Get
                Return ResourceManager.GetString("AssemblyColHeader", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Would you like to save the changes in {0}.
        '''</summary>
        Friend ReadOnly Property CheckUnsavedMsg() As String
            Get
                Return ResourceManager.GetString("CheckUnsavedMsg", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Class ID.
        '''</summary>
        Friend ReadOnly Property ClassIDColHeader() As String
            Get
                Return ResourceManager.GetString("ClassIDColHeader", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to The File &quot;{0}&quot; Does Not Exist.
        '''</summary>
        Friend ReadOnly Property FileNotFound() As String
            Get
                Return ResourceManager.GetString("FileNotFound", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Open File....
        '''</summary>
        Friend ReadOnly Property OpenFile() As String
            Get
                Return ResourceManager.GetString("OpenFile", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Properties.
        '''</summary>
        Friend ReadOnly Property PropertiesText() As String
            Get
                Return ResourceManager.GetString("PropertiesText", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Save File (As)....
        '''</summary>
        Friend ReadOnly Property SaveFile() As String
            Get
                Return ResourceManager.GetString("SaveFile", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Winform Stylesheet|*.wfs|All files|*.*.
        '''</summary>
        Friend ReadOnly Property StyleSheetFileExtensions() As String
            Get
                Return ResourceManager.GetString("StyleSheetFileExtensions", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Type.
        '''</summary>
        Friend ReadOnly Property TypeColHeader() As String
            Get
                Return ResourceManager.GetString("TypeColHeader", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
