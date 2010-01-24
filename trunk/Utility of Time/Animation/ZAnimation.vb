Public Class ZAnimation

    Public Function GetHierarchy(ByVal Data() As Byte, ByVal Bank As Byte) As Limb()
        Dim tOffset As Integer = 0
        Dim tBank As Byte = 0
        Dim tCnt As Integer = 0
        Dim j As Integer = 0
        For i As Integer = 0 To Data.Length - 8 Step 4
            If (Data(i) = Bank) And Data(i + 4) > 0 Then
                tBank = Data(i)
                tCnt = Data(i + 4)
                tOffset = ReadUInt24(Data, i + 1)
                If tOffset < Data.Length - 16 Then
                    For j = tOffset To (tOffset + (tCnt * 4) - 1) Step 4
                        If Data(j) <> tBank Then
                            GoTo nonefound
                        End If
                    Next
                    If i = j Then
                        Dim tmpHierarchy(tCnt - 1) As Limb
                        Dim tmpLimbOff As Integer = 0
                        For k As Integer = 0 To tCnt - 1
                            tmpHierarchy(k) = New Limb
                            tmpLimbOff = ReadUInt24(Data, tOffset + 1)
                            With tmpHierarchy(k)
                                .x = ReadInt16(Data, tmpLimbOff + 0)
                                .y = ReadInt16(Data, tmpLimbOff + 2)
                                .z = ReadInt16(Data, tmpLimbOff + 4)
                                .c0 = CSByte(Data(tmpLimbOff + 6))
                                .c1 = CSByte(Data(tmpLimbOff + 7))

                                If Data(tmpLimbOff + 8) = Bank Then
                                    .DisplayList = ReadUInt24(Data, tmpLimbOff + 9)
                                    ReDim Preserve N64DList(N64DList.Length)
                                    ReadInDL(Data, N64DList, .DisplayList, N64DList.Length - 1)
                                Else
                                    .DisplayList = Nothing
                                End If
                                .r = Rand.NextDouble
                                .g = Rand.NextDouble
                                .b = Rand.NextDouble
                            End With
                            tOffset += 4
                        Next
                        Return tmpHierarchy
                    End If
nonefound:
                End If
            End If
        Next
        Return Nothing
    End Function
    Public Function GetAnimations(ByVal Data() As Byte, ByVal LimbCount As Integer, ByVal Bank As Byte) As Animation()
        Dim animCnt As Integer = -1
        Dim angleOffset As UInteger = 0
        Dim tAnimation(-1) As Animation
        MainWin.AnimationList.Items.Clear()
        For i As Integer = 16 To Data.Length - 8 Step 4
            If (Data(i) = Bank And (Data(i + 4) = Bank) And (Data(i - 3) > 0) And Data(i - 4) = 0) Then
                angleOffset = ReadUInt24(Data, i + 1)
                If angleOffset < Data.Length Then
                    If Data(angleOffset) = 0 And Data(angleOffset + 1) = 0 And ReadInt16(Data, angleOffset + 2) > 0 Then
                        animCnt += 1
                        ReDim Preserve tAnimation(animCnt)
                        With tAnimation(animCnt)
                            .TrackOffset = ReadUInt24(Data, i + 5)
                            .FrameCount = Data(i - 3)
                            .AngleCount = (.TrackOffset - angleOffset) \ 2
                            If .AngleCount < 16384 And .FrameCount > 0 Then
                                .TrackCount = (LimbCount)
                                .ConstTrackCount = Data(i + 9)

                                ReDim .Angles(.AngleCount - 1)
                                ReDim .Tracks(.TrackCount - 1)
                                ReDim .FinalTrack(.TrackCount * 3 - 1)

                                MainWin.AnimationList.Items.Add("0x" & Hex(i))

                                For i1 As Integer = 0 To .AngleCount - 1
                                    .Angles(i1) = CShort(ReadInt16(Data, angleOffset))
                                    angleOffset += 2
                                Next

                                .XTrans = ReadInt16(Data, .TrackOffset + 0)
                                .YTrans = ReadInt16(Data, .TrackOffset + 2)
                                .ZTrans = ReadInt16(Data, .TrackOffset + 4)

                                Dim tTrackOffset As Integer = .TrackOffset + 6

                                Dim tTrack As UInteger = 0
                                For i1 As Integer = 0 To .TrackCount * 3 - 1
                                    tTrack = ReadInt16(Data, tTrackOffset)

                                    If tTrack < .ConstTrackCount Then
                                        ReDim .FinalTrack(i1).Frames(0)
                                        .FinalTrack(i1).Frames(0) = .Angles(tTrack)
                                        .FinalTrack(i1).Type = 0
                                    Else
                                        ReDim .FinalTrack(i1).Frames(.FrameCount - 1)
                                        For i2 As Integer = 0 To .FrameCount - 1
                                            .FinalTrack(i1).Frames(i2) = .Angles(tTrack + i2)
                                        Next
                                        .FinalTrack(i1).Type = 1
                                    End If

                                    tTrackOffset += 2
                                Next
                            Else
                                ReDim Preserve tAnimation(animCnt - 1)
                            End If
                        End With
                    End If
                End If
            End If
        Next
        If tAnimation.Length > 0 Then
            Return tAnimation
        End If
        Return Nothing
    End Function
    Public Function GetTrackRot(ByVal Animation As Animation, ByVal Counter As FPS, ByVal axis As Integer, ByVal Track As Integer) As Double
        'thanks to euler for some of this logic

        Dim tTrack As Integer = Track * 3 + axis

        If tTrack > Animation.FinalTrack.Length - 1 Then
            tTrack = 0
        End If

        Dim Frame As Integer = Counter.CurrFrame
        Dim NextFrame As Integer = Frame + 1

        Dim tFrame0 As Double = 0.0F
        Dim tFrame1 As Double = 0.0F

        With Animation.FinalTrack(tTrack)
            If .Type = 1 Then
                tFrame0 = .Frames(frame)
                If NextFrame > .Frames.Length - 1 Then
                    NextFrame = 0
                End If
                tFrame1 = .Frames(NextFrame)
            Else
                tFrame0 = .Frames(0)
                tFrame1 = .Frames(0)
            End If
        End With

        tFrame0 = AngleToRad(tFrame0)
        tFrame1 = AngleToRad(tFrame1)

        If tFrame1 > (tFrame0 + 180.0F) Then
            tFrame1 -= 360.0F
        End If
        If tFrame1 < (tFrame0 - 180.0F) Then
            tFrame1 += 360
        End If

        Return tFrame0 * (1 - Counter.FrameDelta) + tFrame1 * Counter.FrameDelta
    End Function

    Public Function Animate(ByVal AnimationEntries() As Animation, ByVal Index As Integer, ByVal LoopAnimation As Boolean, ByRef CurrentFrame As TrackBar)
        AnimParser.CountFrames(AnimationStopWatch, 30, ZAnimationCounter)
        If ZAnimationCounter.FrameNo < AnimationEntries(Index).FrameCount - 1 Then
            ZAnimationCounter.CurrFrame = ZAnimationCounter.FrameNo
            CurrentFrame.Value = ZAnimationCounter.CurrFrame
        ElseIf ZAnimationCounter.FrameNo = AnimationEntries(Index).FrameCount - 1 And Not LoopAnimation Then
            AnimParser.ResetAnimation(AnimationStopWatch, ZAnimationCounter)
            AnimParser.StopAnimation(AnimationStopWatch, ZAnimationCounter)
            CurrentFrame.Value = 0
        Else
            AnimParser.ResetAnimation(AnimationStopWatch, ZAnimationCounter)
            AnimParser.StopAnimation(AnimationStopWatch, ZAnimationCounter)
            AnimParser.StartAnimation(AnimationStopWatch, ZAnimationCounter)
            CurrentFrame.Value = 0
        End If
        MainWin.FrameNo.Text = (ZAnimationCounter.CurrFrame + 1).ToString & "/" & CurrentFrame.Maximum + 1
    End Function
    Public Function CountFrames(ByRef AnimationStopWatch As Stopwatch, ByVal FPSRate As Integer, ByRef Counter As FPS)
        With Counter
            .DeltaTime = AnimationStopWatch.Elapsed.TotalSeconds - .LastUpdateTime
            .FramesAdvanced = .FrameDelta + .DeltaTime * FPSRate
            .FramesAdvancedInt = CInt(.FramesAdvanced)
            .FrameNo += .FramesAdvancedInt
            .FrameDelta = .FramesAdvanced - .FramesAdvancedInt
            .LastUpdateTime = AnimationStopWatch.Elapsed.TotalSeconds
        End With
    End Function
    Public Function ResetAnimation(ByRef AnimationStopWatch As Stopwatch, ByRef Counter As FPS)
        With Counter
            .CurrFrame = 0
            .FrameNo = 0
            .FrameDelta = 0
            .FramesAdvanced = 0
            .LastUpdateTime = 0
            .DeltaTime = 0
        End With
        AnimationStopWatch.Reset()
    End Function
    Public Function StartAnimation(ByRef AnimationStopWatch As Stopwatch, ByRef Counter As FPS)
        Counter.Advancing = True
        AnimationStopWatch.Start()
    End Function
    Public Function StopAnimation(ByRef AnimationStopWatch As Stopwatch, ByRef Counter As FPS)
        Counter.Advancing = False
        AnimationStopWatch.Stop()
    End Function
End Class
