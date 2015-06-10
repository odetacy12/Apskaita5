Namespace Workers

    ''' <summary>
    ''' Represents a specific type of work hours (overtime, night work, etc.) 
    ''' for a specific labour contract for a specific month.
    ''' </summary>
    ''' <remarks>Should only be used as a child of <see cref="SpecialWorkTimeItemList">SpecialWorkTimeItemList</see>.
    ''' Values are stored in the database table specialworktimeitems.</remarks>
    <Serializable()> _
    Public Class SpecialWorkTimeItem
        Inherits BusinessBase(Of SpecialWorkTimeItem)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _WorkerID As Integer = 0
        Private _Worker As String = ""
        Private _WorkerPosition As String = ""
        Private _ContractSerial As String = ""
        Private _ContractNumber As Integer = 0
        Private _Type As WorkTimeClassInfo = Nothing
        Private _Day1 As Double = 0
        Private _Day2 As Double = 0
        Private _Day3 As Double = 0
        Private _Day4 As Double = 0
        Private _Day5 As Double = 0
        Private _Day6 As Double = 0
        Private _Day7 As Double = 0
        Private _Day8 As Double = 0
        Private _Day9 As Double = 0
        Private _Day10 As Double = 0
        Private _Day11 As Double = 0
        Private _Day12 As Double = 0
        Private _Day13 As Double = 0
        Private _Day14 As Double = 0
        Private _Day15 As Double = 0
        Private _Day16 As Double = 0
        Private _Day17 As Double = 0
        Private _Day18 As Double = 0
        Private _Day19 As Double = 0
        Private _Day20 As Double = 0
        Private _Day21 As Double = 0
        Private _Day22 As Double = 0
        Private _Day23 As Double = 0
        Private _Day24 As Double = 0
        Private _Day25 As Double = 0
        Private _Day26 As Double = 0
        Private _Day27 As Double = 0
        Private _Day28 As Double = 0
        Private _Day29 As Double = 0
        Private _Day30 As Double = 0
        Private _Day31 As Double = 0
        Private _TotalHours As Double = 0


        ''' <summary>
        ''' Gets an ID of the special work time item that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets an ID of the worker.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="General.Person.ID">Person.ID</see>.
        ''' Value is stored in the database table SpecialWorkTimeItems.WorkerID.</remarks>
        Public ReadOnly Property WorkerID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WorkerID
            End Get
        End Property

        ''' <summary>
        ''' Gets a name of the worker.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="General.Person.Name">Person.Name</see>.</remarks>
        Public ReadOnly Property Worker() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Worker.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets the current worker position as specified in the current labour contract.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property WorkerPosition() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WorkerPosition.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets the serial number (code) of the current labour contract.
        ''' </summary>
        ''' <remarks>A labour contract is identified by a <see cref="SpecialWorkTimeItem.ContractSerial">serial number</see> 
        ''' and <see cref="SpecialWorkTimeItem.ContractNumber">running number</see> pair.
        ''' Value is stored in the database table SpecialWorkTimeItems.ContractSerial.</remarks>
        Public ReadOnly Property ContractSerial() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ContractSerial.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets the running number of the current labour contract.
        ''' </summary>
        ''' <remarks>A labour contract is identified by a <see cref="SpecialWorkTimeItem.ContractSerial">serial number</see> 
        ''' and <see cref="SpecialWorkTimeItem.ContractNumber">running number</see> pair.
        ''' Value is stored in the database table SpecialWorkTimeItems.ContractNumber.</remarks>
        Public ReadOnly Property ContractNumber() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ContractNumber
            End Get
        End Property

        ''' <summary>
        ''' Gets a type of the work time.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.TypeID.</remarks>
        Public ReadOnly Property [Type]() As WorkTimeClassInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type
            End Get
        End Property

        ''' <summary>
        ''' Gets a code of the type of the work time.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property TypeCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type.Code
            End Get
        End Property

        ''' <summary>
        ''' Gets a name of the type of the work time.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property TypeName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type.Name
            End Get
        End Property


        ''' <summary>
        ''' Amount of work hours of specific type in day 1 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day1.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day1() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day1, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day1, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day1 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 2 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day2.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day2() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day2, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day2, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day2 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 3 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day3.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day3() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day3, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day3, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day3 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 4 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day4.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day4() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day4, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day4, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day4 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 5 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day5.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day5() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day5, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day5, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day5 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 6 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day6.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day6() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day6, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day6, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day6 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 7 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day7.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day7() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day7, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day7, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day7 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 8 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day8.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day8() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day8, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day8, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day8 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 9 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day9.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day9() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day9, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day9, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day9 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 10 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day10.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day10() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day10, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day10, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day10 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 11 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day11.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day11() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day11, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day11, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day11 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 12 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day12.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day12() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day12, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day12, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day12 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 13 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day13.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day13() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day13, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day13, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day13 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 14 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day14.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day14() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day14, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day14, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day14 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 15 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day15.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day15() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day15, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day15, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day15 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 16 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day16.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day16() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day16, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day16, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day16 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 17 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day17.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day17() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day17, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day17, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day17 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 18 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day18.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day18() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day18, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day18, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day18 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 19 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day19.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day19() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day19, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day19, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day19 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 20 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day20.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day20() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day20, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day20, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day20 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 21 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day21.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day21() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day21, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day21, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day21 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 22 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day22.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day22() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day22, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day22, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day22 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 23 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day23.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day23() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day23, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day23, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day23 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 24 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day24.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day24() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day24, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day24, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day24 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 25 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day25.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day25() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day25, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day25, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day25 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 26 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day26.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day26() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day26, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Day26, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day26 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 27 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day27.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day27() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day27, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If GetMaxDayCount() > 26 AndAlso CRound(_Day27, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day27 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 28 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day28.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day28() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day28, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If GetMaxDayCount() > 27 AndAlso CRound(_Day28, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day28 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 29 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day29.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day29() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day29, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If GetMaxDayCount() > 28 AndAlso CRound(_Day29, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day29 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 30 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day30.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day30() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day30, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If GetMaxDayCount() > 29 AndAlso CRound(_Day30, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day30 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Amount of work hours of specific type in day 31 of the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.Day31.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKTIME, True, 0.0, 24.0, True)> _
        Public Property Day31() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Day31, ROUNDWORKTIME)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If GetMaxDayCount() > 30 AndAlso CRound(_Day31, ROUNDWORKTIME) <> CRound(value, ROUNDWORKTIME) Then
                    _Day31 = CRound(value, ROUNDWORKTIME)
                    PropertyHasChanged()
                    CalculateTotal()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Total amount of work hours of specific type within the month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table SpecialWorkTimeItems.TotalHours.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, ROUNDWORKTIME)> _
        Public ReadOnly Property TotalHours() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalHours, ROUNDWORKTIME)
            End Get
        End Property



        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return String.Format(My.Resources.Common_ErrorInItem, Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error))
        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return String.Format(My.Resources.Common_WarningInItem, Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning))
        End Function


        Private Sub CalculateTotal()
            _TotalHours = CRound(_Day1 + _Day2 + _Day3 + _Day4 + _Day5 + _Day6 + _
                _Day7 + _Day8 + _Day9 + _Day10 + _Day11 + _Day12 + _Day13 + _Day14 + _
                _Day15 + _Day16 + _Day17 + _Day18 + _Day19 + _Day20 + _Day21 + _Day22 + _
                _Day23 + _Day24 + _Day25 + _Day26 + _Day27 + _Day28 + _Day29 + _Day30 _
                + _Day31, ROUNDWORKTIME)
            PropertyHasChanged("TotalHours")
        End Sub

        Private Function GetMaxDayCount() As Integer
            If Me.Parent Is Nothing Then Return 31
            Return DirectCast(Me.Parent, SpecialWorkTimeItemList).DaysInMonth
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Workers_SpecialWorkTimeItem_ToString, _
                _Type.Code, _Worker, _ContractSerial, _ContractNumber.ToString)
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("TotalHours"))

            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day1"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day2"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day3"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day4"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day5"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day6"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day7"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day8"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day9"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day10"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day11"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day12"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day13"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day14"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day15"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day16"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day17"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day18"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day19"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day20"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day21"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day22"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day23"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day24"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day25"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day26"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day27"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day28"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day29"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day30"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Day31"))

        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewSpecialWorkTimeItem(ByVal baseItem As WorkTimeItem, _
            ByVal nType As WorkTimeClassInfo) As SpecialWorkTimeItem
            Return New SpecialWorkTimeItem(baseItem, nType)
        End Function

        Friend Shared Function GetSpecialWorkTimeItem(ByVal dr As DataRow) As SpecialWorkTimeItem
            Return New SpecialWorkTimeItem(dr)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal dr As DataRow)
            MarkAsChild()
            Fetch(dr)
        End Sub

        Private Sub New(ByVal baseItem As WorkTimeItem, ByVal nType As WorkTimeClassInfo)
            MarkAsChild()
            Create(baseItem, nType)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal baseItem As WorkTimeItem, ByVal nType As WorkTimeClassInfo)

            If nType Is Nothing OrElse Not nType.ID > 0 Then Throw New Exception( _
                My.Resources.Workers_SpecialWorkTimeItem_TypeNull)

            If baseItem Is Nothing Then Throw New Exception(My.Resources.Workers_SpecialWorkTimeItem_WorkerNull)

            If nType.WithoutWorkHours Then Throw New Exception(String.Format( _
                My.Resources.Workers_SpecialWorkTimeItem_InvalidType, nType.Code, nType.Name))

            _WorkerID = baseItem.WorkerID
            _Worker = baseItem.Worker
            _ContractSerial = baseItem.ContractSerial
            _ContractNumber = baseItem.ContractNumber
            _Type = nType

            ValidationRules.CheckRules()

        End Sub

        Private Sub Fetch(ByVal dr As DataRow)

            _ID = CIntSafe(dr.item(0), 0)
            _ContractSerial = CStrSafe(dr.Item(1)).Trim
            _ContractNumber = CIntSafe(dr.Item(2), 0)
            _Day1 = CDblSafe(dr.Item(3), ROUNDWORKTIME, 0)
            _Day2 = CDblSafe(dr.Item(4), ROUNDWORKTIME, 0)
            _Day3 = CDblSafe(dr.Item(5), ROUNDWORKTIME, 0)
            _Day4 = CDblSafe(dr.Item(6), ROUNDWORKTIME, 0)
            _Day5 = CDblSafe(dr.Item(7), ROUNDWORKTIME, 0)
            _Day6 = CDblSafe(dr.Item(8), ROUNDWORKTIME, 0)
            _Day7 = CDblSafe(dr.Item(9), ROUNDWORKTIME, 0)
            _Day8 = CDblSafe(dr.Item(10), ROUNDWORKTIME, 0)
            _Day9 = CDblSafe(dr.Item(11), ROUNDWORKTIME, 0)
            _Day10 = CDblSafe(dr.Item(12), ROUNDWORKTIME, 0)
            _Day11 = CDblSafe(dr.Item(13), ROUNDWORKTIME, 0)
            _Day12 = CDblSafe(dr.Item(14), ROUNDWORKTIME, 0)
            _Day13 = CDblSafe(dr.Item(15), ROUNDWORKTIME, 0)
            _Day14 = CDblSafe(dr.Item(16), ROUNDWORKTIME, 0)
            _Day15 = CDblSafe(dr.Item(17), ROUNDWORKTIME, 0)
            _Day16 = CDblSafe(dr.Item(18), ROUNDWORKTIME, 0)
            _Day17 = CDblSafe(dr.Item(19), ROUNDWORKTIME, 0)
            _Day18 = CDblSafe(dr.Item(20), ROUNDWORKTIME, 0)
            _Day19 = CDblSafe(dr.Item(21), ROUNDWORKTIME, 0)
            _Day20 = CDblSafe(dr.Item(22), ROUNDWORKTIME, 0)
            _Day21 = CDblSafe(dr.Item(23), ROUNDWORKTIME, 0)
            _Day22 = CDblSafe(dr.Item(24), ROUNDWORKTIME, 0)
            _Day23 = CDblSafe(dr.Item(25), ROUNDWORKTIME, 0)
            _Day24 = CDblSafe(dr.Item(26), ROUNDWORKTIME, 0)
            _Day25 = CDblSafe(dr.Item(27), ROUNDWORKTIME, 0)
            _Day26 = CDblSafe(dr.Item(28), ROUNDWORKTIME, 0)
            _Day27 = CDblSafe(dr.Item(29), ROUNDWORKTIME, 0)
            _Day28 = CDblSafe(dr.Item(30), ROUNDWORKTIME, 0)
            _Day29 = CDblSafe(dr.Item(31), ROUNDWORKTIME, 0)
            _Day30 = CDblSafe(dr.Item(32), ROUNDWORKTIME, 0)
            _Day31 = CDblSafe(dr.Item(33), ROUNDWORKTIME, 0)
            _TotalHours = CDblSafe(dr.Item(34), ROUNDWORKTIME, 0)
            _WorkerID = CIntSafe(dr.Item(35), 0)
            _Worker = CStrSafe(dr.Item(36)).Trim
            _WorkerPosition = CStrSafe(dr.Item(37)).Trim
            _Type = HelperLists.WorkTimeClassInfo.GetWorkTimeClassInfo(dr, 38)

            ValidationRules.CheckRules()
            MarkOld()

        End Sub

        Friend Sub Insert(ByVal parent As WorkTimeSheet)

            Dim myComm As New SQLCommand("InsertSpecialWorkTimeItem")
            AddWithParams(myComm)
            myComm.AddParam("?PD", parent.ID)
            myComm.AddParam("?AA", _ContractSerial.Trim)
            myComm.AddParam("?AB", _ContractNumber)
            myComm.AddParam("?BL", _WorkerID)
            myComm.AddParam("?BM", _Type.ID)

            myComm.Execute()

            _ID = Convert.ToInt32(myComm.LastInsertID)

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parent As WorkTimeSheet)

            Dim myComm As New SQLCommand("UpdateSpecialWorkTimeItem")
            myComm.AddParam("?CD", _ID)
            AddWithParams(myComm)

            myComm.Execute()

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()

            Dim myComm As New SQLCommand("DeleteSpecialWorkTimeItem")
            myComm.AddParam("?CD", _ID)

            myComm.Execute()

            MarkNew()

        End Sub

        Private Sub AddWithParams(ByRef myComm As SQLCommand)

            myComm.AddParam("?AC", CRound(_Day1, ROUNDWORKTIME))
            myComm.AddParam("?AD", CRound(_Day2, ROUNDWORKTIME))
            myComm.AddParam("?AE", CRound(_Day3, ROUNDWORKTIME))
            myComm.AddParam("?AF", CRound(_Day4, ROUNDWORKTIME))
            myComm.AddParam("?AG", CRound(_Day5, ROUNDWORKTIME))
            myComm.AddParam("?AH", CRound(_Day6, ROUNDWORKTIME))
            myComm.AddParam("?AI", CRound(_Day7, ROUNDWORKTIME))
            myComm.AddParam("?AJ", CRound(_Day8, ROUNDWORKTIME))
            myComm.AddParam("?AK", CRound(_Day9, ROUNDWORKTIME))
            myComm.AddParam("?AL", CRound(_Day10, ROUNDWORKTIME))
            myComm.AddParam("?AM", CRound(_Day11, ROUNDWORKTIME))
            myComm.AddParam("?AN", CRound(_Day12, ROUNDWORKTIME))
            myComm.AddParam("?AO", CRound(_Day13, ROUNDWORKTIME))
            myComm.AddParam("?AQ", CRound(_Day14, ROUNDWORKTIME))
            myComm.AddParam("?AP", CRound(_Day15, ROUNDWORKTIME))
            myComm.AddParam("?AR", CRound(_Day16, ROUNDWORKTIME))
            myComm.AddParam("?AT", CRound(_Day17, ROUNDWORKTIME))
            myComm.AddParam("?AU", CRound(_Day18, ROUNDWORKTIME))
            myComm.AddParam("?AV", CRound(_Day19, ROUNDWORKTIME))
            myComm.AddParam("?AZ", CRound(_Day20, ROUNDWORKTIME))
            myComm.AddParam("?AW", CRound(_Day21, ROUNDWORKTIME))
            myComm.AddParam("?BA", CRound(_Day22, ROUNDWORKTIME))
            myComm.AddParam("?BB", CRound(_Day23, ROUNDWORKTIME))
            myComm.AddParam("?BC", CRound(_Day24, ROUNDWORKTIME))
            myComm.AddParam("?BD", CRound(_Day25, ROUNDWORKTIME))
            myComm.AddParam("?BE", CRound(_Day26, ROUNDWORKTIME))
            myComm.AddParam("?BF", CRound(_Day27, ROUNDWORKTIME))
            myComm.AddParam("?BG", CRound(_Day28, ROUNDWORKTIME))
            myComm.AddParam("?BH", CRound(_Day29, ROUNDWORKTIME))
            myComm.AddParam("?BI", CRound(_Day30, ROUNDWORKTIME))
            myComm.AddParam("?BJ", CRound(_Day31, ROUNDWORKTIME))
            myComm.AddParam("?BK", CRound(_TotalHours, ROUNDWORKTIME))

        End Sub


#End Region

    End Class

End Namespace