// LIFO = Last In First Out

class Node{
    constructor(val){
        this.next = null;
        this.data = val;
    }
}

class Stack{
    constructor(){
        this.top = null;
    }

    Push(val)
    {
        var node = new Node(val);
        if(!this.top){
            this.top = node;
            return;
        }
        let temp = this.top;
        this.top = node;
        this.top.next = temp;
        return;
    }

    Peek()
    {
        //Code me!
    }

    Pop()
    {
        if(!this.top) return;
        let top = this.top;
        this.top = this.top.next;
        return top.data;
    }

    IsEmpty()
    {
        //Code me!
    }

    Log()
    {
        let str="";
        for(let node=this.top;node;node=node.next)
        {
            str+=node.data+"->";
        }
        console.log(str);
    }
}


let stack=new Stack();
// console.log(stack.IsEmpty()); /* Expected: False */
stack.Push(10);
stack.Push(20);
stack.Push(30);
stack.Push(40);
stack.Log(); /* Expected: 40->30->20->10-> */
console.log(stack.Pop()); /* Expected: 40 */
// console.log(stack.Peek()); /* Expected: 30 */
// stack.Pop(); /* 30 */
// stack.Pop(); /* 20 */
// stack.Pop(); /* 10 */
// console.log(stack.IsEmpty()); /* Expected: true */