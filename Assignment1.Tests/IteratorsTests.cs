namespace Assignment1.Tests;

public class IteratorsTests
{
    [Fact]
    public void Check_If_Returns_1_to_9(){
        // Arrange 
            IEnumerable<int> myList1 = new List<int>()
            {1,2,3};
            IEnumerable<int> myList2 = new List<int>()
            {4,5,6};
            IEnumerable<int> myList3 = new List<int>()
            {7,8,9};

            IEnumerable<IEnumerable<int>> superList = new List<IEnumerable<int>>()
            {myList1,myList2,myList3};

             IEnumerable<int> answer = new List<int>()
            {1,2,3,4,5,6,7,8,9};

        // Act 
            IEnumerable<int> flattenedList = Iterators.Flatten(superList);

        // Assert       
           Assert.Equal(answer, flattenedList);

    }

    [Fact]
     public void Check_If_Returns_Even_2_To_8(){
        // Arrange 
            Predicate<int> even = Even;
            bool Even(int i) => i % 2 == 0;

            IEnumerable<int> myList1 = new List<int>()
            {1,2,3,4,5,6,7,8,9};

            IEnumerable<int> answer = new List<int>()
            {2,4,6,8};

        // Act 
            IEnumerable<int> filteredList = Iterators.Filter(myList1, even);

        // Assert
            Assert.Equal(answer, filteredList);   

    }
}