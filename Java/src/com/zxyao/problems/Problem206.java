package com.zxyao.problems;

/**
 * 206,反转链表
 */
public class Problem206 {
    public static void mainFunc(){
        Problem206 p = new Problem206();
        ListNode head = new ListNode(1);
        ListNode node = head;
        for (int i = 2; i < 6; i++) {
            node.next = new ListNode(i);
            node = node.next;
        }
        System.out.println(p.reverseList(head));
    }

    public ListNode reverseList(ListNode head) {
        recursion (head,null);
        return _head;
    }

    ListNode _head ;
    public void recursion(ListNode cur,ListNode prev){
        if(cur != null){
            recursion(cur.next, cur);
            cur.next = prev;
        }else{
            _head = prev;
        }
    }
}

 class ListNode {
     int val;
     ListNode next;
     ListNode(int x) { val = x; }
 }
