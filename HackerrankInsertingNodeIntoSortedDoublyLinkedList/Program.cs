using HackerrankInsertingNodeIntoSortedDoublyLinkedList;

var input = """
    1
    3
    1
    2
    3
    4
    """;
    
foreach (var (head, data) in ParseInput(input))
    PrintList(sortedInsert(head, data));

static DoublyLinkedListNode sortedInsert(DoublyLinkedListNode head, int data)
{
    if (head == null || data == 0)
        return new DoublyLinkedListNode(data) { };

    if (data < head.data)
    {
        var node = head;
        head = new DoublyLinkedListNode(data) { next = node };
        node.prev = head;

        return head;
    }
    
    var current = head;

    while (current != null && current.data < data)
    {
        if (current.next == null)
        {
            current.next = new DoublyLinkedListNode(data) { prev = current };
            return head;
        }

        current = current.next;
    }

    var prev = current.prev;
    prev.next = new DoublyLinkedListNode(data) {prev = prev, next = current};
    current.prev = prev.next;
    
    return head;
}

static IEnumerable<(DoublyLinkedListNode head, int data)> ParseInput(string input)
{
    var values = input
        .Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
        .Select(int.Parse)
        .ToArray();

    var testCases = values[0];
    var index = 1;

    for (var testCase = 0; testCase < testCases; testCase++)
    {
        var n = values[index++];
        DoublyLinkedListNode head = null;
        DoublyLinkedListNode tail = null;

        for (var i = 0; i < n; i++)
        {
            var node = new DoublyLinkedListNode(values[index++])
            {
                prev = tail
            };

            if (head == null)
                head = node;
            else
                tail.next = node;

            tail = node;
        }

        yield return (head, values[index++]);
    }
}

static void PrintList(DoublyLinkedListNode head)
{
    var values = new List<int>();

    for (var node = head; node != null; node = node.next)
        values.Add(node.data);

    Console.WriteLine(string.Join(" ", values));
}