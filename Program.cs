//*****************************************************************************
//** 3097. Shortest Subarray With OR at Least K II    leetcode               **
//*****************************************************************************

int minimumSubarrayLength(int* nums, int numsSize, int k) {
    int cnt[32] = {0};
    int ans = numsSize + 1;
    int s = 0;
    int i = 0;

    for (int j = 0; j < numsSize; j++) {
        s |= nums[j];

        for (int h = 0; h < 32; h++) {
            if ((nums[j] >> h & 1) == 1) {
                cnt[h]++;
            }
        }

        while (s >= k && i <= j) {
            if (j - i + 1 < ans) {
                ans = j - i + 1;
            }

            for (int h = 0; h < 32; h++) {
                if ((nums[i] >> h & 1) == 1) {
                    if (--cnt[h] == 0) {
                        s ^= (1 << h);
                    }
                }
            }
            i++;
        }
    }

    return ans > numsSize ? -1 : ans;
}