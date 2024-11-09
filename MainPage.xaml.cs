namespace SimpleCollectionView;

public partial class MainPage : ContentPage
{
    private MainViewModel vm;
    public MainPage()
    {
        InitializeComponent();
        vm = (MainViewModel)BindingContext;
    }

    private void OnCollectionViewScrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        vm.FirstVisibleItemIndex = e.FirstVisibleItemIndex;
        vm.LastVisibleItemIndex = e.LastVisibleItemIndex;
        vm.ShowCommandInfo("Scrolled", $"Item {e.FirstVisibleItemIndex} to Item {e.LastVisibleItemIndex}");
    }

    private void OnCollectionSwipedUpDown(object sender, SwipedEventArgs e)
    {
        vm.ShowCommandInfo("Swipe", $"On CollectionView, direction = {(e.Direction == SwipeDirection.Up ? "up" : "down")}");
        CollectionView collectionView = (CollectionView)sender;
        if (e.Direction == SwipeDirection.Up)
            collectionView.ScrollTo(vm.LastVisibleItemIndex, position: ScrollToPosition.Start);
        else
            collectionView.ScrollTo(vm.FirstVisibleItemIndex, position: ScrollToPosition.End);
    }
}
