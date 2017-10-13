using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using PureClarity.Models;

namespace PureClarity.Managers
{
    public class FeedManager
    {
        private string _endpoint;
        private string _accessKey;
        private string _secretKey;

        private ProductCollection _productCollection;
        private DeletedProductCollection _deletedProductCollection;
        private CategoryCollection _categoryCollection;
        private BrandCollection _brandCollection;
        private UserCollection _userCollection;


        public FeedManager(string endpointUrl, string accessKey, string secretKey)
        {
            _endpoint = endpointUrl;
            _accessKey = accessKey;
            _secretKey = secretKey;

            _productCollection = new ProductCollection();
            _categoryCollection = new CategoryCollection();
            _brandCollection = new BrandCollection();
            _userCollection = new UserCollection();
            _deletedProductCollection = new DeletedProductCollection();
        }

        #region Add

        AddItemResult AddProduct(Product product) => _productCollection.AddItem(product);
        IEnumerable<AddItemResult> AddProducts(IEnumerable<Product> products) => _productCollection.AddItems(products);

        AddItemResult AddDeletedProductSku(string productSku)
        {
            return _deletedProductCollection.AddItem(new DeletedProductSku(productSku));
        }
        IEnumerable<AddItemResult> AddDeletedProductSkus(IEnumerable<string> productSkus)
        {
            return _deletedProductCollection.AddItems(productSkus.Select((sku) => { return new DeletedProductSku(sku); }));
        }

        AddItemResult AddCategory(Category category) => _categoryCollection.AddItem(category);
        IEnumerable<AddItemResult> AddCategories(IEnumerable<Category> categories) => _categoryCollection.AddItems(categories);

        AddItemResult AddBrand(Brand brand) => _brandCollection.AddItem(brand);
        IEnumerable<AddItemResult> AddBrands(IEnumerable<Brand> brands) => _brandCollection.AddItems(brands);

        AddItemResult AddUser(User user) => _userCollection.AddItem(user);
        IEnumerable<AddItemResult> AddUsers(IEnumerable<User> users) => _userCollection.AddItems(users);

        #endregion

        #region Remove

        RemoveItemResult RemoveProduct(string productSku) => _productCollection.RemoveItemFromCollection(productSku);
        IEnumerable<RemoveItemResult> RemoveProducts(IEnumerable<string> productSkus) => _productCollection.RemoveItemsFromCollection(productSkus);

        RemoveItemResult RemoveDeletedProductSku(string productSku) => _deletedProductCollection.RemoveItemFromCollection(productSku);
        IEnumerable<RemoveItemResult> RemoveDeletedProductSkus(IEnumerable<string> productSkus) => _deletedProductCollection.RemoveItemsFromCollection(productSkus);

        RemoveItemResult RemoveCategory(string categoryId) => _categoryCollection.RemoveItemFromCollection(categoryId);
        IEnumerable<RemoveItemResult> RemoveCategories(IEnumerable<string> categoryIds) => _categoryCollection.RemoveItemsFromCollection(categoryIds);

        RemoveItemResult RemoveBrand(string brandId) => _brandCollection.RemoveItemFromCollection(brandId);
        IEnumerable<RemoveItemResult> RemoveBrands(IEnumerable<string> brandIds) => _brandCollection.RemoveItemsFromCollection(brandIds);

        #endregion

        #region Validate

        #endregion

    }
}