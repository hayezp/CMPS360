package com.example.springboot;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class HelloController {

	@GetMapping("/")
	public String index() {
		return "Greetings from Spring Boot!";
	}
	@GetMapping("/discount")
    public String discount() {
      int total = 75;

      if (total >= 50) {
        return "You qualify for a discount!";
      } else {
        return "You do not qualify for a discount.";
      }
    }
	@GetMapping("/shipping")
    public String shipping() {
      int orderTotal = 35;

      if (orderTotal >= 50) {
        return "Your order qualifies for free shipping!";
      } else {
        return "Your order does not qualify for free shipping.";
      }
    }
	@GetMapping("/membership")
    public String membership() {
      boolean isMember = true;

      if (isMember) {
        return "You qualify for member benefits!";
      } else {
        return "You are not currently a member.";
      }
    }

	@GetMapping("/stock")
    public String stock() {
      int quantity = 0;

      if (quantity > 0) {
        return "This item is in stock!";
      } else {
        return "Sorry, this item is out of stock.";
      }
    }

}
