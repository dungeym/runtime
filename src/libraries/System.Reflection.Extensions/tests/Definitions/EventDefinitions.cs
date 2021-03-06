// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#pragma warning disable 3026, 0067, 3005 // Disabling a few CLS-compliance warnings

namespace System.Reflection.Tests
{
    public interface IEventTestInterface
    {
        event EventHandler EventPublic;
    }

    public class EventTestBaseClass : IEventTestInterface
    {
        public static int Members = 35;
        public static int MembersEverything = 41;

        public static string[] DeclaredEvents = new string[] { "EventPublic", "EventPublicStatic", "EventInternal", "EventInternalStatic", "EventPrivate", "EventProtected", "EventProtectedStatic" };
        public static string[] InheritedEvents = new string[] { };
        public static string[] InheritedButHiddenEvents = new string[] { };
        public static string[] PublicEvents = new string[] { "EventPublic", "EventPublicStatic" };

        public event EventHandler EventPublic;                    // inherited
        public static event EventHandler EventPublicStatic;       // static members are not inherited

        internal event EventHandler EventInternal;                // not inherited
        internal static event EventHandler EventInternalStatic;   // not inherited

        private event EventHandler EventPrivate;                  // not inherited

        protected event EventHandler EventProtected;              // inherited
        protected static event EventHandler EventProtectedStatic; // not inherited
    }

    public class EventTestSubClass : EventTestBaseClass
    {
        public static new int Members = 7;
        public static new int MembersEverything = 22;
        public static new string[] DeclaredEvents = new string[] { };
        public static new string[] InheritedEvents = new string[] { "EventPublic", "EventInternal", "EventProtected" };
        public static new string[] InheritedButHiddenEvents = new string[] { };
        public static new string[] PublicEvents = new string[] { };
    }

    public class EventTestSubClassWithNewEvents : EventTestSubClass
    {
        public static new int Members = 15;
        public static new int MembersEverything = 29;

        public static new string[] DeclaredEvents = new string[] { "EventProtected", "EventPublicNew" };
        public static new string[] InheritedEvents = new string[] { "EventPublic", "EventInternal" };
        public static new string[] InheritedButHiddenEvents = new string[] { "EventProtected" };
        public static new string[] PublicEvents = new string[] { "EventPublic", "EventPublicNew" };

        new protected event EventHandler EventProtected;        // overrides the ProEvent from EventFieldTest parent
        public event EventHandler EventPublicNew;
    }

    public class EventFieldTestWithIgnoreCase : EventTestSubClassWithNewEvents
    {
        public static new int Members = 23;
        public static new int MembersEverything = 43;

        public static new string[] DeclaredEvents = new string[] { "eVentProtected", "eVentPublicNew", "eVENTInternal", "eVentPriVate" };
        public static new string[] InheritedEvents = new string[] { "EventPublic", "EventInternal", "EventProtected", "EventPublicNew" };
        public static new string[] InheritedButHiddenEvents = new string[] { "EventProtected" };
        public static new string[] PublicEvents = new string[] { "eVentPublicNew", "EventPublic", "EventPublicNew" };

        protected event EventHandler eVentProtected;        // overrides the ProEvent from EventFieldTest parent
        public event EventHandler eVentPublicNew;
        internal static event EventHandler eVENTInternal;
        private event EventHandler eVentPriVate;
    }
}
