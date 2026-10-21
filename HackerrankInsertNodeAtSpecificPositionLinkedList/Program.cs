using HackerrankInsertNodeAtSpecificPositionLinkedList;

var input = """
    3
    16
    13
    7
    1
    2
    """;

var (head, data, position) = ParseInput(input);
var result = insertNodeAtPosition(head, data, position);
PrintList(result);

static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode head, int data, int position)
{
    if (head == null || position == 0)
        return new SinglyLinkedListNode(data) { next = head };

    var count = 1;
    var node = head;

    while (node.next != null && count < position)
    {
        node = node.next;
        count++;
    }
    // count = 1
    // node = 16
    // next = 13

    // count = 2
    // node = 13
    // next = 7

    var next = node.next;
    node.next = new SinglyLinkedListNode(data) { next = next };

    return head;
}

static (SinglyLinkedListNode head, int data, int position) ParseInput(string input)
{
    var lines = input
        .Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
        .Select(int.Parse)
        .ToArray();

    var n = lines[0];

    SinglyLinkedListNode head = null;
    SinglyLinkedListNode tail = null;

    for (var i = 1; i <= n; i++)
    {
        var node = new SinglyLinkedListNode(lines[i]);

        if (head == null)
            head = node;
        else
            tail.next = node;

        tail = node;
    }

    return (head, lines[n + 1], lines[n + 2]);
}

static void PrintList(SinglyLinkedListNode head)
{
    var values = new List<int>();

    for (var node = head; node != null; node = node.next)
        values.Add(node.data);

    Console.WriteLine(string.Join(" ", values));
}