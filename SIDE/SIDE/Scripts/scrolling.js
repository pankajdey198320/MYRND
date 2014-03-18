/*
* Custom Adaptive Scrolling
* author: Stepych - http://csscode.ru
* Website: https://github.com/exewebru/scroll
* version: 1.0
*
*/
function Scroll(box, config) {
    // define config and variables
    var self = this;
    if (typeof box == 'object')
        var config = box,
            box = box.horizontal ? '.scroll-horizontal' : '.scroll';
    else if (!box)var box = '.scroll';
    var _box = $(box);
    // touch start dott
    self.dott = [];
    self.touch = false;
    self.border = [true, true]; // scroll on border

    self.config = $.extend({
        cls : ['scroll-wrap', 'scroll-pane', 'scroll-track', 'scroll-drag'], // classes
        drag_old : false, // html in drag node
        step : 2, // step (speed)å
        start : false, // run all scrolls
        horizontal : false, // horizontal scroll if true
        iDeviceSupport: true // Apple mobile device support
    }, config);
    if (!self.config.iDeviceSupport) {
        if (window.navigator.userAgent.indexOf('iPhone') !== -1 || window.navigator.userAgent.indexOf('iPad') !== -1 || window.navigator.userAgent.indexOf('iPod') !== -1) {
            _box.css('overflow', 'auto');
            return
        }
    }
    if (!!('ontouchstart' in window)) {
        _box.addClass('touch');
        self.config.start = true;
        self.touch = true;
    }
    if (self.config.horizontal) {
        self.tracking = {
            // dev prop
            scrollWidth: null, // width wrapper
            paneWidth : null,
            dragWidth : null,
            dragLeft : 0, // distance from drag to left border box
            dragRight : null // distance from drag to right border box
        };
    } else {
        self.tracking = {
            // dev prop
            scrollHeight: null, // height wrapper
            paneHeight : null,
            dragHeight : null,
            dragTop : 0, // distance from drag to top border box
            dragBot : null
        };
    }
    _box.trigger('scrolling.init', { node: _box, config: self.config, tracking: self.tracking });
    // bind
    $('body').on('mouseenter.scroll', box, function (e) {
        $(this).trigger('scrolling.mouseenter', { node: this, config: self.config, events: e, tracking: self.tracking });
    });
    $('body').on('mouseleave.scroll', box, function (e) {
        $(this).trigger('scrolling.mouseleave', { node: this, config: self.config, events: e, tracking: self.tracking });
    });
    $('body').on('mouseover.scroll touchstart', box, function (e) {
        e.preventDefault();
        var _this = $(this),
            run = _this.find('> .' + self.config.cls[0]).length,
            size = $(e.target).parents(box).length;
        // keep pressing position to determine the delta
        if (self.touch) {
            // left top corner

            if (e.originalEvent !== undefined && e.originalEvent.touches !== undefined) {
                e.originalEvent.pageX = e.originalEvent.touches[0].pageX;
                e.originalEvent.pageY = e.originalEvent.touches[0].pageY;
            }
            else if (e.originalEvent == undefined) {
                e.originalEvent = {
                    pageX: _this.offset().left,
                    pageY: _this.offset().top
                }
            }
            self.dott[0] = e.originalEvent.pageX;
            self.dott[1] = e.originalEvent.pageY;
        }
        if (size > 1) { // scroll in scroll
            _this = _this.find(e.target).closest(box);
        }
        function init() {
            var _wrap = _this.find('> .' + self.config.cls[0]),
                _track = _this.find('> .' + self.config.cls[2]),
                _pane = _wrap.find('> .' + self.config.cls[1]),
                _drag = _track.children();

            if (self.config.horizontal) {
                self.tracking.scrollWidth = _this.width();
                var _childs = _pane.children(), // width pane calculate
                    max_width = _pane.width();
                _childs.each(function (i, el) {
                    var w = $(el).width();
                    if (w > max_width) max_width = w; // define max width
                });
                _pane.width(max_width);
                self.tracking.paneWidth = max_width; // width pane
                self.tracking.dragWidth = self.tracking.paneWidth / self.tracking.scrollWidth;
                self.tracking.dragWidth = Math.round(self.tracking.scrollWidth / self.tracking.dragWidth); // width drag

                if (self.tracking.scrollWidth < self.tracking.paneWidth) _this.addClass('hover').removeClass('scroll-off');
                else {
                    _this.addClass('scroll-off');
                    return false
                }
                _drag.width(self.tracking.dragWidth);

                self.dragPosition = function (pt) {
                    pt = pt != undefined ? pt : self.tracking.dragLeft;
                    self.tracking.dragLeft = pt;
                    self.tracking.dragRight = Math.abs((pt + self.tracking.dragWidth) - self.tracking.scrollWidth);

                    self.tracking.dragRight = self.tracking.dragRight == 1 ? 0 : self.tracking.dragRight; // avoid computation error

                    if (self.tracking.dragLeft == 0 && !self.border[1]) _this.trigger('scrolling.left', { node: this, config: self.config, events: e, tracking: self.tracking });
                    if (self.tracking.dragRight == 0 && !self.border[1]) _this.trigger('scrolling.right', { node: this, config: self.config, events: e, tracking: self.tracking });
                    // avoid repeated calls
                    if (self.tracking.dragLeft == 0 || self.tracking.dragRight == 0) self.border[1] = true;
                    else self.border[1] = false;
                }
            } else {
                self.tracking.scrollHeight = _this.height();
                self.tracking.paneHeight = _pane.height(); // height pane
                self.tracking.dragHeight = self.tracking.paneHeight / self.tracking.scrollHeight;
                self.tracking.dragHeight = Math.round(self.tracking.scrollHeight / self.tracking.dragHeight); // height drag

                if (self.tracking.scrollHeight < self.tracking.paneHeight)_this.addClass('hover').removeClass('scroll-off');
                else {
                    _this.addClass('scroll-off');
                    return false
                }
                _drag.height(self.tracking.dragHeight);

                self.dragPosition = function (pt) {
                    pt = pt != undefined ? pt : self.tracking.dragTop;
                    self.tracking.dragTop = pt;
                    var db = Math.abs((pt + self.tracking.dragHeight) - self.tracking.scrollHeight);
                    self.tracking.dragBot = db == 1 ? 0 : db;

                    if (self.tracking.dragTop == 0 && !self.border[0]) _this.trigger('scrolling.top', { node: this, config: self.config, events: e, tracking: self.tracking });
                    if (self.tracking.dragBot == 0 && !self.border[0]) _this.trigger('scrolling.bottom', { node: this, config: self.config, events: e, tracking: self.tracking });
                    // avoid repeated calls
                    if (self.tracking.dragTop == 0 || self.tracking.dragBot == 0) self.border[0] = true;
                    else self.border[0] = false;
                }
            }
            self.dragPosition();
            _this.trigger('scrolling.mouseover', { node: this, config: self.config, events: e, tracking: self.tracking });

            _wrap.on('mousewheel.scroll DOMMouseScroll.scroll touchmove', function (e) {
                var scrollTo = null,
                    t = $(this);
                if (e.type == 'mousewheel') {
                    try { // for ie <= 8
                        scrollTo = -(e.originalEvent.wheelDelta * self.config.step);
                    } catch (e) {
                    }
                }
                else if (e.type == 'DOMMouseScroll') {
                    try { // for ie <= 8
                        scrollTo = (self.config.step * 2) * e.originalEvent.detail;
                    } catch (e) {
                    }
                }
                else if (e.type == 'touchmove' && e.originalEvent) {
                    var delta = 1,
                        pageY = e.originalEvent.touches !== undefined ? e.originalEvent.touches[0].pageY : e.originalEvent.pageY,
                        pageX = e.originalEvent.touches !== undefined ? e.originalEvent.touches[0].pageX : e.originalEvent.pageX;
                    // X or Y orienteer
                    if (self.config.horizontal)
                        pageX > self.dott[0] ? delta = -1 : delta = 1;
                    else
                        pageY > self.dott[1] ? delta = -1 : delta = 1;
                    scrollTo = delta * self.config.step * 2;
                }

                if (scrollTo) {
                    if (self.config.horizontal) {
                        t.scrollLeft(scrollTo + t.scrollLeft());
                        var drag_width = self.tracking.paneWidth / self.tracking.scrollWidth,
                            maxScroll = self.tracking.paneWidth - self.tracking.scrollWidth,
                            pt = _pane.position().left;
                        pt = Math.round(-pt / drag_width);
                        _drag.css('margin-left', pt + 'px');
                    } else {
                        t.scrollTop(scrollTo + t.scrollTop());
                        var drag_height = self.tracking.paneHeight / self.tracking.scrollHeight,
                            maxScroll = self.tracking.paneHeight - self.tracking.scrollHeight,
                            pt = _pane.position().top;
                        pt = Math.round(-pt / drag_height);
                        _drag.css('margin-top', pt + 'px');
                    }

                    self.dragPosition(pt);
                    t.parent().trigger('scrolling.scroll', { node: this, config: self.config, events: e, tracking: self.tracking });
                    if (self.config.horizontal) {
                        if (t.scrollLeft() === 0) return; // focus window scrolling
                        else if (t.scrollLeft() === maxScroll) return;
                    } else {
                        if (t.scrollTop() === 0) return; // focus window scrolling
                        else if (t.scrollTop() === maxScroll) return;
                    }
                    return false;
                }
            });
        }

        function create() { // create track
            _this.addClass('runned');
            if (self.config.drag_old)
                var html_track = '<div class="' + self.config.cls[2] + '"><div class="' + self.config.cls[3] + '">' + self.config.drag_old + '</div></div>';
            else
                var html_track = '<div class="' + self.config.cls[2] + '"><div class="' + self.config.cls[3] + '">' + '</div></div>';

            _this.wrapInner('<div class="' + self.config.cls[0] + '"><div class="' + self.config.cls[1] + '"></div></div>');
            _this.append(html_track);
            _this.css('overflow', 'hidden');
            var wrap = _this.find('.' + self.config.cls[0]);
            wrap.scrollTop(0);
            wrap.scrollLeft(0); // set in 0
            _this.trigger('scrolling.scroll', { node: _this, config: self.config, events: e, tracking: self.tracking });
            _this.trigger('scrolling.create', { node: _this, config: self.config, events: e, tracking: self.tracking });
            init();
        }

        if (!run)create();
        else init();
    });
    // Sets the position of artificial
    $('body').on('scrolling.set', box, function (e) {
        var _this = $(this),
            _wrap = _this.find('>.' + self.config.cls[0]),
            _drag = _wrap.next().find('>.' + self.config.cls[3]),
            _pane = _wrap.find('>.' + self.config.cls[1]), // .scroll-pane
            data = {
                X : e.scrollX || 0,
                Y : e.scrollY || 0,
                duration: e.duration || 0,
                easing : e.easing || 'swing'
            },
            setDragPos = function (route, type) {
                var pt = _pane.position()[route], sw_size = _wrap[type](), drag_size = _pane[type]() / sw_size;
                pt = Math.round((-pt / drag_size));
                _drag.css('margin-' + route, pt + 'px');
            };

        if (window.getSelection) window.getSelection().removeAllRanges();

        if (data.X) {
            if (data.X.indexOf('+') != -1) {
                data.X = ~~data.X.match(/[0-9]+/)[0];
                data.X = _wrap.scrollTop() + data.X;
            } else if (data.X.indexOf('-') != -1) {
                data.X = ~~data.X.match(/[0-9]+/)[0];
                data.X = _wrap.scrollTop() - data.X;
            }
            _wrap.animate({ scrollLeft: ~~data.X }, { queue: false, easing: data.easing, duration: ~~data.duration, step: function (now, fx) {
                setDragPos('left', 'width');
                _this.trigger('scrolling.scroll');
            } });
        }
        if (data.Y) {
            if (data.Y.indexOf('+') != -1) {
                data.Y = ~~data.Y.match(/[0-9]+/)[0];
                data.Y = _wrap.scrollTop() + data.Y;
            } else if (data.Y.indexOf('-') != -1) {
                data.Y = ~~data.Y.match(/[0-9]+/)[0];
                data.Y = _wrap.scrollTop() - data.Y;
            }
            _wrap.animate({ scrollTop: ~~data.Y }, { queue: false, easing: data.easing, duration: ~~data.duration, step: function () {
                setDragPos('top', 'height');
                _this.trigger('scrolling.scroll');
            }});
        }
    });
    // hover
    $('body').on('mouseout.scroll touchend', box, function (e) {
        $(this).removeClass('hover');
        $(this).find('.' + self.config.cls[0]).off('mousewheel.scroll DOMMouseScroll.scroll');
        $(this).trigger('scrolling.mouseout', { node: this, config: self.config, events: e, tracking: self.tracking });
    });

    // mouse scroll
    $('body').on({
        mousedown: function (e) {
            var _currentElement = $(e.target),
            // if HTML has in drag-node
                _drag = _currentElement.hasClass(self.config.cls[3]) ? _currentElement :
                    _currentElement.closest('.' + self.config.cls[3]).length ? _currentElement.closest('.' + self.config.cls[3]) : false;
            if (!_drag) return; // Click outside the body drag-teg
            var _this = _drag.parent().parent(), // .scroll
                de, bl, ctfix = null;

            _this.addClass('mousedown');
            if (!-[1, ])_this.attr('unselectable', 'on');
            $('html').attr('onselectstart', 'return false').addClass('user-select-none');

            var hd = self.config.horizontal ? _drag.width() : _drag.height(),
                _pane = _this.children().children().filter('.' + self.config.cls[1]),
                _wrap = _this.children().filter('.' + self.config.cls[0]),
                wh = self.config.horizontal ? _wrap.width() : _wrap.height(),
                st = self.config.horizontal ? _this.offset().left : _this.offset().top,
                pb = wh - hd;
            $('body').on('mousemove.scroll', function (e) {
                e.preventDefault();
                if (window.getSelection) window.getSelection().removeAllRanges();
                var ot = self.config.horizontal ? e.pageX : e.pageY, // height from cursor to document
                    dt = parseInt(self.config.horizontal ? _drag.css('margin-left') : _drag.css('margin-top')), // height from drag to wrapper
                    ct = ot - st;
                if (de == null)de = ct - dt; // save height for click

                var res = ct - de, // result
                    bl = dt + hd; // bottom line drag

                // lock drag
                if (res < 0)res = 0;
                else if (bl >= wh) {
                    res = pb;
                    if (ctfix == null)ctfix = ct;
                    if (ctfix > ct)res -= 1;
                }

                // set value
                self.config.horizontal ? _drag.css('margin-left', res + 'px') : _drag.css('margin-top', res + 'px');

                self.config.horizontal ? _wrap.scrollLeft((res * _pane.width() / wh)) : _wrap.scrollTop((res * _pane.height() / wh));

                self.dragPosition(res);

                _this.trigger('scrolling.mousemove', { node: this, config: self.config, events: e, tracking: self.tracking });
                _this.trigger('scrolling.scroll', { node: this, config: self.config, events: e, tracking: self.tracking });
            });
            _drag.parent().parent().trigger('scrolling.mousedown', { node: this, config: self.config, events: e, tracking: self.tracking });
        },
        mouseup : function (e) {
            $(this).trigger('scrolling.mouseup', { node: this, config: self.config, events: e, tracking: self.tracking });
        }
    }, box);
    $('body').on('mouseup', function (e) {
        _box.removeClass('mousedown');
        if (!-[1, ])$(this).removeAttr('unselectable');
        $('html').removeAttr('onselectstart').removeClass('user-select-none');
        $(this).off('mousemove.scroll');
    });
    if (self.config.start) {
        // run after load
        _box.trigger('mouseover').trigger('mouseout');
        if (self.touch) _box.trigger('touchstart');
    }
    // load plugin
    _box.trigger('scrolling.inited', { node: _box, config: self.config, tracking: self.tracking });
} // class Scroll;


