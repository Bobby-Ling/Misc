#include <stdio.h>
#include <stdlib.h>
#include <ucontext.h>
#include <signal.h>
/* The three contexts:
 *    (1) main_context1 : The point in main to which loop will return.
 *    (2) main_context2 : The point in main to which control from loop will
 *                        flow by switching contexts.
 *    (3) loop_context  : The point in loop to which control from main will
 *                        flow by switching contexts. */
ucontext_t main_context1, main_context2, loop_context;

/* The iterator return value. */
volatile int i_from_iterator;

/* This is the iterator function. It is entered on the first call to
 * swapcontext, and loops from 0 to 9. Each value is saved in i_from_iterator,
 * and then swapcontext used to return to the main loop.  The main loop prints
 * the value and calls swapcontext to swap back into the function. When the end
 * of the loop is reached, the function exits, and execution switches to the
 * context pointed to by main_context1. */
void loop(
    ucontext_t *loop_context,
    ucontext_t *other_context,
    int *i_from_iterator) {
    int i;

    for (i = 0; i < 10; ++i) {
        /* Write the loop counter into the iterator return location. */
        *i_from_iterator = i;

        /* Save the loop context (this point in the code) into ''loop_context'',
         * and switch to other_context. */
        swapcontext(loop_context, other_context);
    }

    /* The function falls through to the calling context with an implicit
     * ''setcontext(&loop_context->uc_link);'' */
}

int main(void) {
    /* The stack for the iterator function. */
    char iterator_stack[SIGSTKSZ];

    /* Flag indicating that the iterator has completed. */
    volatile int iterator_finished;

    getcontext(&loop_context); // 获取当前上下文并保存到 ucp 指向的结构体中
    /* Initialise the iterator context. uc_link points to main_context1, the
     * point to return to when the iterator finishes. */
    loop_context.uc_link = &main_context1; // 指向当当前上下文执行完后应该恢复的上下文
    loop_context.uc_stack.ss_sp = iterator_stack; // 指向上下文的栈
    loop_context.uc_stack.ss_size = sizeof(iterator_stack);

    /* Fill in loop_context so that it makes swapcontext start loop. The
     * (void (*)(void)) typecast is to avoid a compiler warning but it is
     * not relevant to the behaviour of the function. */
    makecontext(&loop_context, (void (*)(void)) loop,
        3, &loop_context, &main_context2, &i_from_iterator); //修改上下文 ucp 以便它在被激活时执行函数 func
    // 这里执行的相当于swapcontext(&loop_context, &main_context2);
    /* Clear the finished flag. */
    iterator_finished = 0;

    /* Save the current context into main_context1. When loop is finished,
     * control flow will return to this point. */
    getcontext(&main_context1);
    // 因为loop_context.uc_link = &main_context1; 完成loop后会跑到这里来
    if (!iterator_finished) {
        /* Set iterator_finished so that when the previous getcontext is
         * returned to via uc_link, the above if condition is false and the
         * iterator is not restarted. */
        iterator_finished = 1;

        while (1) {
            /* Save this point into main_context2 and switch into the iterator.
             * The first call will begin loop.  Subsequent calls will switch to
             * the swapcontext in loop. */
            swapcontext(&main_context2, &loop_context); // 保存当前上下文到 oucp，并切换到 ucp 指向的上下文
            printf("%d\n", i_from_iterator);
        }
    }

    return 0;
}

/*
https://www.hitzhangjie.pro/libmill-book/basics/context-switching.html
https://en.wikipedia.org/wiki/Setcontext

main_context1在68行被设置, loop函数退出时loop函数绑定的loop_context将被销毁,
程序中会隐式调用setcontext(loop_context.uc_link)来切换到父上下文中去执行,
即getcontext(&main_context1)对应的下一条指令地址处(70行).

main函数执行时, 什么时候激活loop函数呢, 在while循环内swapcontext的时候(80行),
执行到这里的时候, main函数将当前上下文信息存储到main_context2, 并切换到loop_context去执行, 执行什么呢?
50行~61行定义了loop_context的父上下文, 以及loop_context绑定的函数执行时要采用的栈空间,
当然还绑定了要执行的函数loop以及传递给loop的参数信息. loop函数将使用数组iterator_stack[SIGSTKSZ]作为自己的栈空间.

loop执行起来之后, 会进入一个循环, 每轮循环会更新一下变量i_from_iterator的值, 然后呢,
就执行上下文切换swapcontext(loop_context, other_context), 这里的other_context刚好是main_context2,
切过去之后就是执行语句printf("%d\n", i_from_iterator)来完成变量的打印.
然后进入while(1)循环, 此时又会执行上下文切换继续执行loop函数, loop函数从上次停下来的地方继续执行, 这样连续打印了0~9.

然后, loop函数for循环结束, 退出函数, loop_context结束, 此时函数退出前会隐式调用setcontext以切换到父上下文main_context1去执行,
由于前面main函数执行时已经将变量iterator_finished更新为了1, 所以此时即便从main_context1继续执行, 也不会再次进入while循环再次执行loop函数.

最后, 程序正常结束.
*/