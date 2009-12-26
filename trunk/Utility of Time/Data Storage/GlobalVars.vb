Imports System.IO
Module GlobalVars

#Region "Application Variables"
    Public winh As Integer = 0
    Public winw As Integer = 0
    Public ogltop As Integer = 0
    Public oglleft As Integer
    Public CurrentBank As Integer = 0
    Public winresw As String = ""
    Public winresh As String = ""
    Public MaxAnisotropy() As Single = {0.0F}
    Public DefROM As String = ""
    Public args() As String = {""}
    Public HighlightShader As String = "!!ARBfp1.0" & Environment.NewLine & _
                                       "OUTPUT FinalColor = result.color;" & Environment.NewLine & _
                                       "MOV FinalColor, {1.0,0.0,0.0,0.3};" & Environment.NewLine & _
                                       "END"
    Public HighlightProg As Integer
    Public envlightoff As Integer = 0
    Public CamXPos As Double = 0
    Public CamYPos As Double = 0
    Public CamZPos As Double = 0
    Public objectset As Integer = 0
    Public OnSceneActor As Boolean = False
    Public ActorType As Integer = 0
    Public sceneused As Boolean = False
    Public envboxoff As Integer = 0
    Public HotKeys() As Keys

#End Region
#Region "Scene Actor Variables"

    Public SelectedRoomActors As New ArrayList
    Public SelectedSceneActors As New ArrayList
    Public actornp As New ArrayList
    Public actorvp As New ArrayList
    Public actorgp As New ArrayList
    Public actornpu As New ArrayList
    Public actorvpu As New ArrayList
    Public actorgpu As New ArrayList
    Public groupcntoff As Integer = 0
    Public groupcnt As Integer = 0
    Public sceneobjset As Int32 = 0
    Public doorxoff As New ArrayList
    Public doorvar As New ArrayList
    Public doorno1 As New ArrayList
    Public scenedoorcnt As Integer = 0

#End Region
#Region "Map Actor Variables"
    Public ActorGroups As New ArrayList
    Public ActorGroupOffset
#End Region

#Region ""
    Public PickedEntities As New PickedItems
    Public ZFileBuffer As Byte()
    Public ZSceneBuffer As Byte()
    Public CommonBank1 As Byte()
    Public CommonBank2 As Byte()
    Public GLExtensions As OpenGLExtensions
    Public ParseDL As New F3DEX2_Parser
    Public CompileDL As New N64DlistAssembler
    Public ParseOBJ As New OBJParser
    Public RSPInterpreter As New MIPS
    Public CMDLow As UInt32
    Public CMDHigh As UInt32
#End Region
    Public RGBA As New TextureUpscaler.RGBA
    Public CI As New TextureUpscaler.CI
    Public IA As New TextureUpscaler.IA
    Public I As New TextureUpscaler.I
End Module

