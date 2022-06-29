// Queue - First in first out

class Node {
    constructor(val) {
        this.data = val;
        this.next = null;
    }
}

class Queue {
    constructor() {
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
        if (this.isEmpty()) {
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
        if (this.isEmpty()) {
            return "the queue is empty";
        } else {
            let temp = this.top;
            this.top = this.top.next;
            return temp;
        }
    }

    // IsEmpty - return true or false whether the queue is empty
    isEmpty() {
        return this.top == null;
    }

    // Front - return the first item without removing it
    front() {
        if (this.isEmpty()) {
            return "Queue is empty"
        } else {
            console.log(`the front is ${this.top.data}`)
            return this.top.data;
        }
    }

    // Compare queues using the built in methods you have written so far for Queues
    compare(otherQ) {
        if(this.length != otherQ.length){
            return false;
        } else {
            let runner1 = this.top;
            let runner2 = otherQ.top;
            while(runner1){
                if(runner1.data != runner2.data){
                    return false;
                }
                runner1 = runner1.next;
                runner2 = runner2.next;
            }
        return true;
        }
    }

    // Return true or false whether a queue is a palindrome, also using only built in methods
    isPalindrome() {
        let temp = new Queue();
        let runner1 = this.top;
        while(runner1){
            temp.enqueue(runner1.data);
            runner1 = runner1.next;
        }
        temp.print();
        let q2 = new Queue();
        let runner = temp.top;
        while(runner){
            q2.enqueue(temp.dequeue().data);
            // q2.enqueue(temp.front());
            // temp.dequeue();
            runner = runner.next;
        }
        this.print()
        q2.print()
        return this.compare(q2);
    }
}

let queue = new Queue();
queue.print();
queue.enqueue(1);
queue.enqueue(2);
queue.enqueue(2);
queue.enqueue(1);



// let queue2 = new Queue();
// queue2.print();
// queue2.enqueue(1);
// queue2.enqueue(2);
// queue2.enqueue(3);
// queue2.enqueue(4);
// queue2.print();

// console.log(queue.compare(queue2));
console.log(queue.isPalindrome());