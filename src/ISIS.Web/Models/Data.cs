using System;
using System.Collections.Generic;

namespace ISIS.Web.Models
{
    public static class Data
    {

        public static class Instructors
        {
            public static readonly Instructor JaneSmith = new Instructor("Jane", "Smith");
            public static readonly Instructor JohnSmith = new Instructor("John", "Smith");
            public static readonly Instructor JasonMason = new Instructor("Jason", "Mason");
            public static readonly Instructor JonathanMcDonald = new Instructor("Jonathan", "McDonald");
            public static readonly Instructor ClintDentler = new Instructor("Clint","Dentler");
            public static readonly Instructor JoeWalters = new Instructor("Joe", "Walters");

            public static readonly List<Instructor> AllInstructors = new List<Instructor>(
                new[] {JaneSmith, JohnSmith, JasonMason, JonathanMcDonald, ClintDentler, JoeWalters});

            static Instructors()
            {
                var math = new[]
                               {
                                   Courses.Algebra,
                                   Courses.DevEdMath3,
                                   Courses.Trig,
                                   Courses.Calc1,
                                   Courses.Calc2
                               };

                JoeWalters.Courses.AddRange(math);
                JaneSmith.Courses.AddRange(math);
                JohnSmith.Courses.AddRange(math);
                JasonMason.Courses.AddRange(new[] {Courses.DevEdMath3, Courses.Algebra});

                JonathanMcDonald.Courses.AddRange(new[] {Courses.Physics});
                ClintDentler.Courses.AddRange(new[] {Courses.Biology, Courses.AP});
            }
        }

        public static class Rooms
        {
            public static Room A164 = new Room("A164", 25);
            public static Room S105 = new Room("S105", 18);
            public static Room D101 = new Room("D101", 25);
            public static Room D102 = new Room("D102", 25);
            public static Room D105 = new Room("D105", 23);
            public static Room D106 = new Room("D106", 25);
            public static Room D107 = new Room("D107", 25);
            public static Room D201 = new Room("D201", 25);
            public static Room D202 = new Room("D202", 25);
            public static Room D205 = new Room("D205", 25);
            public static Room D206 = new Room("D206", 25);
            public static Room D207 = new Room("D207", 25);
            public static Room Online = new Room("Online", int.MaxValue);

            public static readonly List<Room> AllRooms = new List<Room>(
                new[] {A164, S105, D101, D102, D105, D106, D107, D201, D202, D205, D206, D207});

            static Rooms()
            {
                foreach (var room in AllRooms)
                {
                    room.Equipment["PC"] = 1;
                    room.Equipment["Whiteboard"] = 1;
                    room.Equipment["Projector"] = 1;
                }

                S105.Equipment["PC"] = 16;
                D105.Equipment["PC"] = 25;
                D205.Equipment["PC"] = 20;

                D107.Equipment["Lab Sink"] = 20;
            }
        }

        public static class Courses
        {
            public static readonly Course DevEdMath3 = new Course("MATH", "0309", "Developmental Math");
            public static readonly Course Algebra = new Course("MATH", "1301", "College Algebra");
            public static readonly Course Trig = new Course("MATH", "1302", "Trigonometry");
            public static readonly Course Calc1 = new Course("MATH", "2301", "Calculus 1");
            public static readonly Course Calc2 = new Course("MATH", "2302", "Calculus 2");
            public static readonly Course Biology = new Course("BIOL", "1301", "Biology 1");
            public static readonly Course AP = new Course("BIOL", "1313", "Anatomy and Physiology");
            public static readonly Course Physics = new Course("PHYS", "2301", "Physics");

            public static readonly List<Course> AllMath = new List<Course>(new[] {DevEdMath3, Algebra, Trig, Calc1, Calc2});
        }

        public static class Templates
        {

            public static readonly Template BasicDevEd3 = new Template("Basic DevEd 3", Courses.DevEdMath3, 20);
            public static readonly Template BasicAlgebra = new Template("Basic Algebra", Courses.Algebra, 20);
            public static readonly Template BasicTrig = new Template("Basic Trig", Courses.Trig, 20);
            public static readonly Template BasicCalc1 = new Template("Basic Calc 1", Courses.Calc1, 20);
            public static readonly Template BasicCalc2 = new Template("Basic Calc 2", Courses.Calc2, 20);
            public static readonly Template BasicBiol = new Template("Basic Biology", Courses.Biology, 20);
            public static readonly Template BasicAP = new Template("Basic A&P", Courses.AP, 20);
            public static readonly Template BasicPhysics = new Template("Basic Physics", Courses.Physics, 20);

            public static readonly Template CompDevEd3 = new Template("Computer-aided DevEd 3", Courses.DevEdMath3, 15);

            public static readonly Template JohnsOnlineAlgebra = new Template("John's online algebra", Courses.Algebra,
                                                                              40) {Room = Rooms.Online};

            public static readonly Template CompAlgebra = new Template("Computer-aided algebra", Courses.Algebra, 20);

            public static readonly Template BiologyLab = new Template("Biology in the lab", Courses.Biology, 20)
                                                             {Room = Rooms.D107};

            public static readonly List<Template> AllTemplates = new List<Template>(
                new[]
                    {
                        BasicAlgebra, BasicAP, BasicBiol, BasicCalc1, BasicCalc2, BasicDevEd3, BasicPhysics, BasicTrig,
                        CompDevEd3, JohnsOnlineAlgebra, CompAlgebra
                    });

            static Templates()
            {
                foreach (var tmpl in AllTemplates)
                    tmpl.InstructorEquipment.AddRange(new []{"PC", "Whiteboard"});
                JohnsOnlineAlgebra.InstructorEquipment.Clear();
                CompDevEd3.StudentEquipment.Add("PC");
                CompAlgebra.StudentEquipment.Add("PC");
            }

        }


    }
}