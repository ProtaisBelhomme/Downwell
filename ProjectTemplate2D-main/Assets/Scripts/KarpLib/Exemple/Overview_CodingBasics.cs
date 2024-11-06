using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Overview_CodingBasics : MonoBehaviour
{
    #region Variables Essential
    public int publicInt = 0;
    public bool publicBool = false;
    public float publicFloat = 0.0f;
    public string publicString = "Hello World!";
    #endregion

    #region Unity Variables Essential
    public Vector3 publicVector3 = Vector3.zero;
    public Vector2 publicVector2 = Vector2.zero;

    public GameObject publicGameObject = null;
    public Transform publicTransform = null;
    public RectTransform publicRectTransform = null;
    #endregion

    #region Collections Essential
    //Basic Collections
    public int[] publicIntArray = new int[0];
    public List<int> publicIntList = new List<int>();
    public Dictionary<string, int> publicIntDictionary = new Dictionary<string, int>();

    //Other Collections
    public Queue<int> publicIntQueue = new Queue<int>();
    public Stack<int> publicIntStack = new Stack<int>();

    public HashSet<int> publicIntHashSet = new HashSet<int>();
    public LinkedList<int> publicIntLinkedList = new LinkedList<int>();
    #endregion

    #region Attribute Essential
    // SerializeField allows private variables to be shown in the Inspector
    [SerializeField] private int privateInt = 0;
    // HideInInspector hides a variable from the Inspector
    [HideInInspector] public int hiddenInt = 0;
    // Range limits the value of a variable in the Inspector
    [Range(0, 10)] public int rangedInt = 0;
    // Tooltip adds a tooltip to a variable in the Inspector
    [Tooltip("This is a tooltip")] public int tooltipInt = 0;
    // Multiline allows a string to be displayed over multiple lines in the Inspector
    [Multiline] public string multilineString = "Hello\nWorld!";

    // Header adds a header to a variable in the Inspector
    [Header("This is a header")] public int headerInt = 0;
    // Space adds space between variables in the Inspector
    [Space] public int spacedInt = 0;

    // AddComponentMenu adds a component to the GameObject menu
    [AddComponentMenu("KarpGame/FalconPunch")]
    // RequireComponent automatically adds required components to the GameObject
    [RequireComponent(typeof(Rigidbody))]
    public class FalconPunch : MonoBehaviour
    {
    }
    #endregion

    #region Enum Essential
    public enum MyEnum { First, Second, Third }

    // Enum Flags (allows multiple values to be selected)
    [Flags]
    public enum MyFlags
    {
        First = 1,
        Second = 2,
        Third = 4
    }
    // Enum Flags using bitshift
    [Flags]
    public enum MyFlagsBitshift
    {
        First = 1 << 0,
        Second = 1 << 1,
        Third = 1 << 2
    }

    // Enum Variables
    public MyEnum myEnum = MyEnum.First;
    public MyFlags myFlag = MyFlags.First;

    /// Explain bitwise operation
    /// ^ : XOR
    /// | : OR
    /// & : AND
    /// ~ : NOT

    // Enum Flags Methods
    public bool HasFlag(MyFlags flag)
    {
        return (myFlag & flag) == flag;
    }
    public void AddFlag(MyFlags flag)
    {
        myFlag |= flag;
    }
    public void RemoveFlag(MyFlags flag)
    {
        myFlag &= ~flag;
    }
    public void ToggleFlag(MyFlags flag)
    {
        myFlag ^= flag;
    }

    #endregion

    #region Property Essential
    // Property Declaration
    private int _propertyInt;
    public int PropertyIntGetterSetter
    {
        get { return _propertyInt; }
        set { _propertyInt = value; }
    }

    // Auto-Property (automatically generates a private variable)
    public int AutoPropertyInt { get; set; }

    // Useful for variables that should not be modified outside the class
    public int ReadOnlyPropertyInt { get; private set; }

    // Hidden Property (visible in the Inspector)
    [field: SerializeField]
    public int ReadOnlyPropertyIntVisibleInInspector { get; private set; }

    // Computed Property (uses a method to calculate the value)
    public int ComputedPropertyInt
    {
        get { return 0 + 1 + 2 + 3 + 4; }
    }
    // Can be written in a single line
    public int ComputedPropertyIntOneLine => 0 + 1 + 2 + 3 + 4;
    #endregion

    #region Methods Essential
    public void MethodOverload() { }
    // Method Overloading (methods with the same name but different parameters)
    public void MethodOverload(int value) { }
    // Optional Parameters (parameters with default values)
    public void MethodOverload(Vector2 value, string text = "defaultValue") { }

    // Static Method (can be called without an instance of the class)
    public static void StaticMethod() { }
    // Virtual Method (can be overridden in a subclass)
    public virtual void VirtualMethod() { }
    #endregion

}
