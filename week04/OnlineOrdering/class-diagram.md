

class Address {
  - _street : string
  - _city : string
  - _stateProvince : string
  - _country : string
  + Address(street : string, city : string, stateProvince : string, country : string)
  + IsInUSA() : bool
  + GetFullAddress() : string
}

class Customer {
  - _name : string
  - _address : Address
  + Customer(name : string, address : Address)
  + LivesInUSA() : bool
  + GetName() : string
  + GetAddressString() : string
}

class Product {
  - _name : string
  - _productId : string
  - _pricePerUnit : decimal
  - _quantity : int
  + Product(name : string, productId : string, pricePerUnit : decimal, quantity : int)
  + GetName() : string
  + GetProductId() : string
  + GetTotalCost() : decimal
}

class Order {
  - _products : List<Product>
  - _customer : Customer
  + Order(customer : Customer)
  + AddProduct(product : Product) : void
  + GetTotalPrice() : decimal
  + GetPackingLabel() : string
  + GetShippingLabel() : string
}

Customer "1" --> "1" Address : has-a
Order "1" --> "1" Customer : has-a
Order "1" --> "0..*" Product : contains
