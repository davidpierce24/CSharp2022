// Queue - First in first out

class Node{
    constructor(val){
        this.data = val;
        this.next = null;
    }
}

class Queue{
    constructor(){
        this.top = null;
        this.tail = null;
        // keep track of the length
        this.length = 0;
    }

    print() {
        var arr = [];
        var runner = this.top;

        while (runner) {
            arr.push(runner.data);
            runner = runner.next;
        }
        console.log(arr);
    }

    // Enqueue - add an item and return the new size of the queue
    enqueue(val) {
        let node = new Node(val);
        if(this.isEmpty()){
            this.top = node;
            this.tail = node;
            this.length++;
            return this.length;
        } else {
            this.tail.next = node;
            this.tail = this.tail.next;
            this.length++;
            return this.length;
        }
    }

    // Dequeue - remove and return the first item
    dequeue() {
        if(this.isEmpty()){
            return "the queue is empty";
        } else {
            let runner = this.top;
            while (runner.next.next){
                runner = runner.next;
            }
            this.tail = runner;
            this.tail.next = null;
            return this;
        }
    }

    // IsEmpty - return true or false whether the queue is empty
    isEmpty() {
        return this.top == null;
    }

    // Front - return the first item without removing it
    front() {
        if(this.isEmpty()){
            return "Queue is empty"
        } else {
            console.log(`the front is ${this.top.data}`)
            return this.top.data;
        }
    }
}

let queue = new Queue();
queue.print();
queue.enqueue(1);
queue.enqueue(2);
queue.enqueue(3);
queue.print();
queue.dequeue();
queue.print();
queue.front();