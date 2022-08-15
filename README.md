# WebApiCoreSwagger
 Web API на ASP.Net Core и использование Swagger
 Implementation of API CRUD methods Http:  
 [HttpGet] Get() - the whole list of products in json;
 [HttpGet("{id}")]   Get(int id) - the product in json by ID;
 [HttpDelete("{id}")] Delete(int id) - delete product by ID;
 [HttpPost] Post(Product product) - create product with generated ID;
 [HttpPut] Put(Product product) - update product by ID;
