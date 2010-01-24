Public Module Structs

#Region "Unspecific"
    Public Structure Color3UByte
        Dim r As Byte
        Dim g As Byte
        Dim b As Byte
    End Structure
    Public Structure Color4UByte
        Dim r As Byte
        Dim g As Byte
        Dim b As Byte
        Dim a As Byte
    End Structure
    Structure OpenGLExtensions
        Dim GLMultiTexture As Boolean
        Dim GLFragProg As Boolean
        Dim GLAnisotropic As Boolean
        Dim GLMultiSample As Boolean
        Dim GLSL As Boolean
        Dim AnisotropicSamples() As Single
    End Structure
    Structure WOGLExtensions
        Dim WGLMultiSample As Boolean
        Dim MultiSampleLevels() As Single
    End Structure
    Structure RendererOptions
        Dim Textures As Boolean
        Dim ColorCombiner As Boolean
        Dim AntiAliasing As Boolean
        Dim Anisotropic As Boolean
    End Structure
    Public Structure BankSwitch
        Dim Bank04 As Integer
        Dim Bank05 As Integer
        Dim AnimBank As Integer
    End Structure
    Enum UseBank
        Inline = -1
        Item0 = 0
        Item1 = 1
        Item2 = 2
        Item3 = 3
    End Enum
#End Region

#Region "Zelda Animation"
    Public Structure Limb
        Dim r As Double
        Dim g As Double
        Dim b As Double
        Dim x As Short
        Dim y As Short
        Dim z As Short
        Dim c0 As SByte
        Dim c1 As SByte
        Dim DisplayList As UInteger
    End Structure
    Public Structure AnimTrackIndex
        Dim XRot As UInteger
        Dim YRot As UInteger
        Dim ZRot As UInteger
    End Structure
    Public Structure AnimTrack
        Dim Frames() As Short
        Dim Type As Integer '0 = constant, 1 = keyframe
    End Structure
    Public Structure Animation
        Dim Angles() As Short
        Dim Tracks() As AnimTrackIndex
        Dim FinalTrack() As AnimTrack
        Dim XTrans As UInteger
        Dim YTrans As UInteger
        Dim ZTrans As UInteger
        Dim FrameOffset As UInteger
        Dim TrackOffset As UInteger
        Dim FrameCount As UInteger
        Dim AngleCount As UInteger
        Dim TrackCount As UInteger
        Dim ConstTrackCount As Integer
    End Structure
    Public Structure FPS
        Dim Advancing As Boolean
        Dim FrameNo As Integer
        Dim CurrFrame As Integer
        Dim Frames As Double
        Dim CurrentTime As Double
        Dim LastUpdateTime As Double
        Dim ElapsedTime As Double
        Dim DeltaTime As Double
        Dim FramesAdvanced As Double
        Dim FramesAdvancedInt As Integer
        Dim FrameDelta As Double
        Dim FPS As Double
    End Structure
#End Region

#Region "Zelda Level handling"
    Public Structure Rooms
        Dim startoff As Integer
        Dim endoff As Integer
    End Structure

    Public Structure Actor
        Dim x As Short
        Dim y As Short
        Dim z As Short
        Dim xr As Short
        Dim yr As Short
        Dim zr As Short
        Dim no As UInt32
        Dim var As UInt32
        Dim offset As UInt32
        Dim pickR As Byte
        Dim pickG As Byte
        Dim pickB As Byte
        Dim picked As Boolean
        Dim ident As String
        Dim DisplayLists() As N64DisplayList
    End Structure
    Public Structure MapOffset
        Dim StartOff As UInt32
        Dim EndOff As UInt32
    End Structure
    Public Structure Door
        Dim x As Short
        Dim y As Short
        Dim z As Short
        Dim yr As Short
        Dim no As UInt32
        Dim var As UInt32
        Dim offset As UInt32
        Dim loadMapFront As Byte
        Dim loadMapBack As Byte
        Dim pickR As Byte
        Dim pickG As Byte
        Dim pickB As Byte
    End Structure
    Public Structure Exits
        Dim Index As UInteger
        Dim scOff As UInteger
    End Structure
    Public Structure CollisionTriColorSelect
        Dim g As Short
        Dim b As Short
    End Structure
    Public Structure CollisionTypes
        Dim scOff As UInt32
        Dim unk1 As UInt32
        Dim unk2 As UInt32
        Dim unk3 As UInt32
        Dim unk4 As UInt32
        Dim WalkOnSound As Byte
    End Structure
    Public Structure CollisionTypePresets
        Dim Data As String
        Dim Description As String
        Dim Index As String
        Dim Type As String
    End Structure
    Public Structure CollisionVertex
        Dim x As ArrayList
        Dim y As ArrayList
        Dim z As ArrayList
        Dim VertR As ArrayList
        Dim VertG As ArrayList
        Dim VertB As ArrayList
        Dim EdgeR As ArrayList
        Dim EdgeG As ArrayList
        Dim EdgeB As ArrayList
        Dim FaceR As ArrayList
        Dim FaceG As ArrayList
        Dim FaceB As ArrayList
    End Structure
    Public Structure PolygonCollision
        Dim scOff As UInt32
        Dim Param As Integer
        Dim A As Integer
        Dim B As Integer
        Dim C As Integer
        Dim nX As Short
        Dim nY As Short
        Dim nZ As Short
        Dim pickR As Byte
        Dim pickG As Byte
        Dim pickB As Byte
    End Structure
#End Region

#Region "Geometry"
    Structure N64Vertex
        Dim x() As Short
        Dim y() As Short
        Dim z() As Short
        Dim u() As Short
        Dim v() As Short
        Dim r() As Byte
        Dim g() As Byte
        Dim b() As Byte
        Dim a() As Byte
    End Structure
#End Region

#Region "Zelda File tables"
    Public Structure ActorTbl
        Dim Startoff As UInteger
        Dim Endoff As UInteger
        Dim StartVoff As UInteger
        Dim EndVoff As UInteger
    End Structure
    Public Structure ObjectTbl
        Dim Startoff As UInteger
        Dim Endoff As UInteger
    End Structure
#End Region

#Region "Zelda File storage"
    Public Enum FileTypes
        MAP = 1
        ACTORMODEL = 0
        ACTORCODE = 2
    End Enum
    Public Structure ObjectExchange
        Dim Bank4 As Bank04
        Dim Bank5 As Bank05
        Dim Anims As AnimBank
    End Structure
    Public Structure Bank04
        Dim Banks() As BankBuffers
    End Structure
    Public Structure Bank05
        Dim Banks() As BankBuffers
    End Structure
    Public Structure AnimBank
        Dim Banks() As BankBuffers
    End Structure
    Public Structure BankBuffers
        Dim Name As String
        Dim StartOffset As UInteger
        Dim EndOffset As UInteger
        Dim Data() As Byte
    End Structure
    Public Structure ZFileTypes
        Dim Levels() As ZSc
        Dim Objects() As ZObj
        Dim ActorCode() As ZCodeFiles
        Dim Others() As ZOtherData
    End Structure
    Public Structure ZMap
        Dim startoff As Integer
        Dim endoff As Integer
        Dim filename As String
    End Structure
    Public Structure ZSc
        Dim startoff As Integer
        Dim endoff As Integer
        Dim filename As String
        Dim Maps() As ZMap
    End Structure
    Public Structure ZObj
        Dim startoff As Integer
        Dim endoff As Integer
        Dim filename As String
    End Structure
    Public Structure ZCodeFiles
        Dim startoff As Integer
        Dim endoff As Integer
        Dim filename As String
    End Structure
    Public Structure ZOtherData
        Dim startoff As Integer
        Dim endoff As Integer
        Dim filename As String
    End Structure
    Public Structure FileBuffers
        Dim Level() As Byte
        Dim Map() As Byte
        Dim ActorModel() As Byte
    End Structure
    Structure ZSegment
        Dim Bank As Byte
        Dim Offset As UInteger
    End Structure
#End Region

#Region "Display Lists"
    Public Enum UCodes
        RDP = 0
        F3DEX = 1
        F3DEX2 = 2
    End Enum
    Structure DLCommand
        Dim CMDParams() As Byte
        Dim CMDHigh As UInteger
        Dim CMDLow As UInteger
        Dim Name As String
        Dim DLPos As Integer
    End Structure
    Structure N64DisplayList
        Dim Skip As Boolean
        Dim Highlight As Boolean
        Dim PickCol As Color3UByte
        Dim StartPos As ZSegment
        Dim EndPos As ZSegment
        Dim CommandCount As Integer
        Dim Commands() As DLCommand
        Dim CommandsCopy() As DLCommand
    End Structure
    Structure ZCamera
        Dim x As Short
        Dim y As Short
        Dim z As Short
    End Structure
    Structure OGLDisplayList
        Dim MainDL As Integer
        Dim HighlighterDL As Integer
        Dim PickableDL As Integer
        Dim PickR As Byte
        Dim PickG As Byte
        Dim PickB As Byte
        Dim N64Offset As Integer
        Dim Highlight As Boolean
        Dim Skip As Boolean
    End Structure
    Structure GeometryAvgPos
        Dim xAvg As Short
        Dim yAvg As Short
        Dim zAvg As Short
    End Structure
    Structure ShaderCache
        Dim MUXS0 As UInteger
        Dim MUXS1 As UInteger
        Dim Equation() As String
        Dim FragShader As UInteger
    End Structure


    Structure Texture
        Dim ID As Integer
        Dim DXT As Integer
        Dim Height As Integer
        Dim Width As Integer
        Dim RealWidth As Integer
        Dim RealHeight As Integer
        Dim TextureHRatio As Double
        Dim TextureWRatio As Double
        Dim TexBytes As UInteger
        Dim ImageBank As Integer
        Dim PalBank As Integer
        Dim Offset As Integer
        Dim PalOff As Integer
        Dim TexFormat As Integer
        Dim TexelSize As Integer
        Dim CMS As Integer
        Dim CMT As Integer
        Dim S_Scale As Double
        Dim T_Scale As Double
        Dim ShiftS As Double
        Dim ShiftT As Double
        Dim TShiftS As Double
        Dim TShiftT As Double
        Dim MaskS As Integer
        Dim MaskT As Integer
        Dim LineSize As Integer
        Dim ULS As Integer
        Dim ULT As Integer
        Dim LRS As Integer
        Dim LRT As Integer
        Dim OGLTexObj As UInteger
        Dim Palette32() As Color4UByte
    End Structure
    Structure TCache
        Dim Texture As Texture
    End Structure
#Region "DL Compiler"
    Structure UnpackedCombiner
        Dim cA() As UInteger
        Dim cB() As UInteger
        Dim cC() As UInteger
        Dim cD() As UInteger
        Dim aA() As UInteger
        Dim aB() As UInteger
        Dim aC() As UInteger
        Dim aD() As UInteger
    End Structure
    Structure UnpackedGeometryMode
        Dim ZBUFFER As Boolean
        Dim CULLBACK As Boolean
        Dim CULLFRONT As Boolean
        Dim FOG As Boolean
        Dim LIGHTING As Boolean
        Dim TEXTUREGEN As Boolean
        Dim TEXTUREGENLINEAR As Boolean
        Dim SHADINGSMOOTH As Boolean
    End Structure
    Structure UnpackedVtxLoad
        Dim Count As UInteger
        Dim Offset As ZSegment
        Dim Length As UInteger
        Dim n0 As UInteger
        Dim v0 As UInteger
    End Structure
    Structure UnpackedOtherModesL
        Dim AAEN As Boolean
        Dim ZCMP As Boolean
        Dim ZUPD As Boolean
        Dim IMRD As Boolean
        Dim CLRONCVG As Boolean
        Dim CVGDSTWRAP As Boolean
        Dim CVGDSTFULL As Boolean
        Dim CVGDSTSAVE As Boolean
        Dim ZMODEINTER As Boolean
        Dim ZMODEXLU As Boolean
        Dim ZMODEDEC As Boolean
        Dim CVGXALPHA As Boolean
        Dim ALPHACVGSEL As Boolean
        Dim FORCEBL As Boolean
        Dim MDSFT As Byte
    End Structure
    Structure UnpackedTriangle
        Dim TRI2 As Boolean
        Dim VertA As Byte
        Dim VertB As Byte
        Dim VertC As Byte
        Dim _VertA As Byte
        Dim _VertB As Byte
        Dim _VertC As Byte
    End Structure
#End Region
#End Region

#Region "Editing features"
    Structure Tools
        Dim CurrentTool As Integer
        Dim SelectedItemType As Integer
        Dim Axis As Integer
        Dim AxisDisp As String
        Dim ToolDisp As String
        Dim NoDepthTest As Boolean
    End Structure
    Structure DLEdit
        Dim PrimColor As DLCommand
        Dim EnvColor As DLCommand
    End Structure
    Structure PickableItems
        Dim r As Byte
        Dim g As Byte
        Dim b As Byte
        Dim a As Byte
    End Structure
    Structure PickedItems
        Dim CollisionTriangles() As PickableItems
        Dim CollisionVertices() As PickableItems
        Dim GraphicsVertices() As PickableItems
        Dim RoomActors() As PickableItems
        Dim SceneActors() As PickableItems
        Dim LinkActors() As PickableItems
    End Structure
#End Region

End Module
