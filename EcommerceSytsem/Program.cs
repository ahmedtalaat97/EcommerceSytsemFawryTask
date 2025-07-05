namespace EcommerceSytsem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------Start Fawry Task-------------");


            DateTime Today = DateTime.Today;


            EcommerceSystem ecommerceSystem = new EcommerceSystem();

            Console.WriteLine("-----------init products------------ ");

            Product cheese = new Product(name: "Cheese", price: 100, stockQuantity: 10, canBeShipped: true, canExpire: true, expiryDate: Today.AddDays(20), weight: 200);
            Product biscuits = new Product("Biscuits", 50.0, 15, canBeShipped: true, weight: 350, canExpire: true, expiryDate: Today.AddDays(-5));
            Product tv = new Product("TV", 5000.0, 3, canBeShipped: true, weight: 5000);
            Product mobileScratchCard = new Product("Mobile Scratch Card", 100.0, 50, canBeShipped: false);
            Product laptop = new Product("Laptop", 8000.0, stockQuantity:10, canBeShipped: true, weight: 3000);
            Product outOfStockItem = new Product("Rare Collectible", 1000.0, 0, canBeShipped: false);


            ecommerceSystem.AddProduct(cheese);
            ecommerceSystem.AddProduct(biscuits);
            ecommerceSystem.AddProduct(tv);
            ecommerceSystem.AddProduct(mobileScratchCard);
            ecommerceSystem.AddProduct(laptop);
            ecommerceSystem.AddProduct(outOfStockItem);

            Customer talaat = new Customer("AhmedTalaat", 15000);
            Customer Ahmed = new Customer("Hamada", 25);

            Console.WriteLine("---------customer init---------");
            Console.WriteLine($"{talaat.Name} has {talaat.Balance}");

            Console.WriteLine($"{Ahmed.Name} has {Ahmed.Balance}");


            // first  tests

            Console.WriteLine("------- 1- Test Successful Checkout-------------");

            ShoppingCart cart = new ShoppingCart();

            try
            {

                cart.AddItem(cheese, 2);
                cart.AddItem(tv, 1);
                cart.AddItem(mobileScratchCard, 1);

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Failed to add items {ex.Message}");
            }

            CheckoutResult firstResult = ecommerceSystem.Checkout(talaat, cart);

            if (firstResult.Success)
            {
                Console.WriteLine(firstResult.ShippmentNotice);
                Console.WriteLine(firstResult.Receipt);
                Console.WriteLine($"Customer current balance after payment {firstResult.CustomerNewBalance}");
            }

            Console.WriteLine("-------------------------------------");

            // second test

            Console.WriteLine("------- 2- Test Empty Cart-------------");

            ShoppingCart emptyCart= new ShoppingCart();

            CheckoutResult emptyCaseResult = ecommerceSystem.Checkout(talaat, emptyCart);
            Console.WriteLine(emptyCaseResult.Message);

            Console.WriteLine("-------------------------------------");


            // third test 

            Console.WriteLine("------- 3- Test Insufficent customer balance-------------");

            ShoppingCart insufficentCart= new ShoppingCart();

            try
            {
                insufficentCart.AddItem(laptop, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($" failed to add item {ex.Message}");
            }
                CheckoutResult insufficentResult = ecommerceSystem.Checkout(Ahmed, insufficentCart);

                Console.WriteLine(insufficentResult.Message);



            Console.WriteLine("-------------------------------------");

            Console.WriteLine("------ Test Case 4 Product Out of Stock -------");

            ShoppingCart outofStock = new ShoppingCart();

            try
            {
                outofStock.AddItem(outOfStockItem, 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Caught exception {ex.Message}");
                
            }

            CheckoutResult outOfStockResult = ecommerceSystem.Checkout(Ahmed,outofStock);

            Console.WriteLine(outOfStockResult.Message);


            Console.WriteLine("-------------------------------------");

            Console.WriteLine("------ Test Case 5 expired product  -------");

            ShoppingCart expiredCart = new ShoppingCart();

            try
            {
                expiredCart.AddItem(biscuits, 1);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"caught exception {ex.Message}");
            }

            CheckoutResult expiredCheckout=ecommerceSystem.Checkout(talaat, expiredCart);
            Console.WriteLine(expiredCheckout.Message);

            Console.WriteLine("-------------------------------------");

            Console.WriteLine("------ Test Case 6 Adding more than available stock to cart  -------");

            ShoppingCart moreAvalCart=new ShoppingCart();

            try
            {
                moreAvalCart.AddItem(cheese, 8);
                moreAvalCart.AddItem(cheese, 1);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"caught exception {ex.Message}");
            }
            
            CheckoutResult moreAvalResult=ecommerceSystem.Checkout(talaat, moreAvalCart);
            Console.WriteLine(moreAvalResult.Message);


            Console.WriteLine("-------------------------------------");

            Console.WriteLine("------ Test Case 7 no shipped items  -------");


            ShoppingCart noShippedItemsCart = new ShoppingCart();
            try
            {
                noShippedItemsCart.AddItem(mobileScratchCard, 5);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"caught ex {ex.Message}");
            }
            CheckoutResult noShippedResult = ecommerceSystem.Checkout(talaat, noShippedItemsCart);
            if(noShippedResult.Success)
            {
                Console.WriteLine(noShippedResult.ShippmentNotice);
                Console.WriteLine(noShippedResult.Receipt);
                Console.WriteLine($"Customer current balance after payment {noShippedResult.CustomerNewBalance}");
            }

            Console.WriteLine("-------------------------------------");

            Console.WriteLine("--- Final Customer Balances ---");

            Console.WriteLine($"{talaat.Name} balance : {talaat.Balance}");

            Console.WriteLine($"{Ahmed.Name} balance : {Ahmed.Balance}");


        }
    }
}
