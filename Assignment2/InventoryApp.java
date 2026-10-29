package Assignment2;

import javax.swing.JOptionPane;

public class InventoryApp {
    public static void main(String[] args) {

        Product product1 = new Product("Notebook", 5.99, 10);
        Product product2 = new Product("Pen", 1.50, 20);

        // Display inventory information
        System.out.println("Store Inventory");

        System.out.println("Product: " + product1.getName());
        System.out.println("Price: $" + product1.getPrice());
        System.out.println("Quantity: " + product1.getQuantity());
        System.out.printf("Total Value: $%.2f%n", product1.calculateValue());

        System.out.println();

        System.out.println("Product: " + product2.getName());
        System.out.println("Price: $" + product2.getPrice());
        System.out.println("Quantity: " + product2.getQuantity());
        System.out.printf("Total Value: $%.2f%n", product2.calculateValue());

        // Display inventory in a pop-up window
       String message = "Store Inventory\n\n"
          + "Product: " + product1.getName() + "\n"
          + "Price: $" + product1.getPrice() + "\n"
          + "Quantity: " + product1.getQuantity() + "\n"
          + String.format("Total Value: $%.2f\n\n", product1.calculateValue())
          + "Product: " + product2.getName() + "\n"
          + "Price: $" + product2.getPrice() + "\n"
          + "Quantity: " + product2.getQuantity() + "\n"
          + String.format("Total Value: $%.2f", product2.calculateValue());

        JOptionPane.showMessageDialog(null, message, "Inventory Application",
          JOptionPane.INFORMATION_MESSAGE);
    
    
    }
}
