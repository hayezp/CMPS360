package Assignment2;

public class Product {

    private String name;
    private double price;
    private int quantity;

    public Product(String name, double price, int quantity) {
      this.name = name;
      this.price = price;
      this.quantity = quantity;
    }

    public double calculateValue() {
      return price * quantity;
    }

    public String getName() {
      return name;
    }

    public double getPrice() {
      return price;
    }

    public int getQuantity() {
      return quantity;
    }
}
