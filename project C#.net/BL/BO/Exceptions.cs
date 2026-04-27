namespace BO;

// חריגה כללית עבור שכבת ה-BL
[Serializable]
public class BlException : Exception
{
    public BlException(string message) : base(message) { }
    public BlException(string message, Exception innerException) : base(message, innerException) { }
}

// חריגה למקרה שבו אובייקט (מוצר/לקוח/הזמנה) לא נמצא
[Serializable]
public class BlDoesNotExistException : Exception
{
    public BlDoesNotExistException(string message) : base(message) { }
    public BlDoesNotExistException(string message, Exception innerException) : base(message, innerException) { }
}

// חריגה למקרה שמנסים להוסיף אובייקט שכבר קיים (למשל לקוח עם אותו ת"ז)
[Serializable]
public class BlAlreadyExistsException : Exception
{
    public BlAlreadyExistsException(string message) : base(message) { }
    public BlAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }
}

// חריגה עבור נתונים לא תקינים (למשל מחיר שלילי או כמות לא מספיקה במלאי)
[Serializable]
public class BlInvalidDataException : Exception
{
    public BlInvalidDataException(string message) : base(message) { }
}