/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package iteja0.pkg11assignment2026;

/**
 *
 * @author ryanloedolf
 */
public class StudentClass {
    
    private String name;
    private int Energy;
    private int academicScore;
    
    public StudentClass(String name){
    
        this.name = name;
        this.Energy = 70;
        this.academicScore = 1;
    }
    
    public void updateEnergy(int amount){
    
        this.Energy += amount;
    }
    
    public void updateScore(int amount){
    
        this.academicScore += amount;
    }
    
    public String GetName() {return name; }
    public int GetEnergy() {return Energy; }
    public int getAcademicScore() {return academicScore; }
}
