public class ItemsControllerTests
{
    [Fact]
    public void GetItem_ReturnsNotFound_WhenItemDoesNotExist()
    {
        // Arrange
        var mockService = new Mock<IItemService>();
        mockService.Setup(service => service.GetById(0)).Returns((Item)null);
        var controller = new ItemsController(mockService.Object);

        // Act
        var result = controller.GetItem(0);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }
}
