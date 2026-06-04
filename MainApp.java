package iteja0.pkg11assignment2026;
import java.util.Scanner;

public class MainApp {

    static Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) {

        System.out.println("Welcome to the Eduvos First Week Simulator");

        String name = "";
        while (true) {
            System.out.print("Enter your name (letters only): ");
            name = scanner.nextLine().trim();
            if (name.matches("[a-zA-Z]+")) {
                break;
            }
            System.out.println("Invalid name. Try again.");
        }

        StudentClass student = new StudentClass(name);

        DayOfTheWeek[] days = {
            new NewClassPerDay.RegistrationDay(),
            new NewClassPerDay.LectureDay(),
            new NewClassPerDay.AssignmentDay(),
            new NewClassPerDay.StudyDay(),
            new NewClassPerDay.TestDay()
        };

        int day = 1;

        for (int i = 0; i < days.length; i++) {
            System.out.println("\n-- Day " + day + " --");
            System.out.println("Energy: " + student.GetEnergy());
            System.out.println("Academic Score: " + student.getAcademicScore());

            days[i].playScenario(student);

            if (student.GetEnergy() <= 0) {
                System.out.println("\nNo more energy. Game over, " + student.GetName() + ".");
                return;
            }

            day++;
        }

        System.out.println("\n-- End of Week --");
        System.out.println("Final Academic Score: " + student.getAcademicScore());

        int score = student.getAcademicScore();

        if (score <= 40) {
            System.out.println("Low performance Work on attendance.");
        } else if (score <= 60) {
            System.out.println("Average performance, Improve.");
        } else {
            System.out.println("Good! You had a successfull first weeek.");
        }
    }
}