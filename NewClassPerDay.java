package iteja0.pkg11assignment2026;

public class NewClassPerDay {

    public static class RegistrationDay extends DayOfTheWeek {
        @Override
        public void playScenario(StudentClass student) {
            System.out.println("Day 1 - Registration Day");
            System.out.println("1: Go early");
            System.out.println("2: Go late");
            int choice = getChoice(1, 2);
            if (choice == 1) {
                student.updateScore(+10);
                student.updateEnergy(-10);
            } else {
                student.updateScore(+5);
                student.updateEnergy(-5);
            }
        }
    }

    public static class LectureDay extends DayOfTheWeek {
        @Override
        public void playScenario(StudentClass student) {
            System.out.println("Day 2 - Lecture Day");
            System.out.println("1: Go to lecture");
            System.out.println("2: Be late");
            System.out.println("3: Skip");
            int choice = getChoice(1, 3);
            if (choice == 1) {
                student.updateScore(+15);
                student.updateEnergy(-15);
            } else if (choice == 2) {
                student.updateScore(0);
                student.updateEnergy(+5);
            } else {
                student.updateScore(0);
                student.updateEnergy(+10);
            }
        }
    }

    public static class AssignmentDay extends DayOfTheWeek {
        @Override
        public void playScenario(StudentClass student) {
            System.out.println("Day 3 - Assignment");
            System.out.println("1: Start it now");
            System.out.println("2: Do it later");
            int choice = getChoice(1, 2);
            if (choice == 1) {
                student.updateScore(+20);
                student.updateEnergy(-20);
            } else {
                student.updateScore(+5);
                student.updateEnergy(-5);
            }
        }
    }

    public static class StudyDay extends DayOfTheWeek {
        @Override
        public void playScenario(StudentClass student) {
            System.out.println("Day 4 - Study");
            System.out.println("1: Study with friends");
            System.out.println("2: Study by myself");
            int choice = getChoice(1, 2);
            if (choice == 1) {
                student.updateScore(+15);
                student.updateEnergy(-10);
            } else {
                student.updateScore(+10);
                student.updateEnergy(-10);
            }
        }   
    }

    public static class TestDay extends DayOfTheWeek {
        @Override
        public void playScenario(StudentClass student) {
            System.out.println("Day 5 - Test Day");
            System.out.println("1: I studied");
            System.out.println("2: I did not study");
            int choice = getChoice(1, 2);
            if (choice == 1) {
                student.updateScore(+25);
                student.updateEnergy(-20);
            } else {
                student.updateScore(+10);
                student.updateEnergy(-10);
            }
        }
    }
}