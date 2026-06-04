package iteja0.pkg11assignment2026;
import java.util.Scanner;

public abstract class DayOfTheWeek {

    private Scanner scanner = new Scanner(System.in);

    public abstract void playScenario(StudentClass student);

    protected int getChoice(int min, int max) {
        while (true) {
            System.out.print("Enter choice (" + min + "-" + max + "): ");
            try {
                int choice = Integer.parseInt(scanner.nextLine().trim());
                if (choice >= min && choice <= max) {
                    return choice;
                }
                System.out.println("Enter a number between " + min + " and " + max + ".");
            } catch (NumberFormatException e) {
                System.out.println("Numbers only.");
            }
        }
    }
}