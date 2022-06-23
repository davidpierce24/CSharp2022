// node and dll classes

// node class
class Node {
    constructor(value) {
        this.data = value;
        this.next = null;
        this.prev = null;
    }
}

// dll class
class DLL {
    // this creates a list with nothing inside of it
    constructor() {
        this.head = null;
        this.tail = null;
    }

    insertAtFront(val){
        var node = new Node(val);
        if(this.head == null){
            this.head = node;
            this.tail = node;
        } else {
            var temp = this.head;
            this.head = node;
            
        }
    }
}